namespace RelativityServerImportPluginConsole
{
	using Relativity.Server.DataExchange.Wrapper;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.IO;
	using System.Linq;
	using System.Net.Http;
	using System.Text;

	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			try
			{
				ExecuteDemo();
				Console.WriteLine("CONSOLE - Demo Completed.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			Console.WriteLine("CONSOLE - Press any key to exit.");
			Console.ReadKey();
		}

		private static void ExecuteDemo()
		{
			// Note: the legacy/SDK plugins are separated into completely different folders.
			string rootSolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\");
			string datasetDirectory = System.IO.Path.Combine(rootSolutionDirectory, @"Dataset");
			string legacyPluginDirectory = System.IO.Path.Combine(rootSolutionDirectory, @"Plugins\Legacy");
			string sdkPluginDirectory = System.IO.Path.Combine(rootSolutionDirectory, @"Plugins\Sdk");
			Version MinSdkVersion = new Version(9, 7, 229, 5);

			// Note: the legacy API does NOT support bearer token auth!
			ImportConnectionInfo connectionInfo = new ImportConnectionInfo
			{
				Password = "PASSWORD",
				UserName = "USERNAME",
				UseRsaBearerToken = false,
				WebServiceUrl = "https://HOSTNAME/RelativityWebApi/",
				WorkspaceId = 1234567
			};

			// Note: specify the full path where each plugin directory is located.
			PluginConfiguration pluginConfiguration = new PluginConfiguration
			{
				LegacyPluginDirectory = legacyPluginDirectory,
				SdkPluginDirectory = sdkPluginDirectory
			};

			// Note: the context decouples import events away from the import job and consistent with the existing object model.
			ImportContext context = new ImportContext();
			context.Complete += (sender, e) =>
			{
				Console.WriteLine("[Completed Event] Total imported: {0}, Total doc-level errors: {1}",
					e.TotalImportCount, e.TotalErrorCount);
			};

			context.Error += (sender, e) =>
			{
				Dictionary<string, object> dict = e.Row.Keys.Cast<string>()
					.ToDictionary(key => key, key => e.Row[key]);
				Console.WriteLine("[Error Event] Name Value Pairs: {0}",
					string.Join(",", dict.Select(x => x.Key + "=" + x.Value)));
			};

			context.FatalException += (sender, e) => { Console.WriteLine("[Fatal Exception Event] {0}", e.Exception); };
			context.Message += (sender, e) => { Console.WriteLine("[Message Event] {0}", e.Message); };
			context.Progress += (sender, e) => { Console.WriteLine("[Progress Event] Row number: {0}", e.Row); };
			context.ProcessProgress += (sender, e) => { Console.WriteLine("[Progress Process Event] Total processed records: {0}", e.TotalRecordsProcessed); };

			// Ensure all plugin related resources are disposed once the import has completed.
			using (ImportClientPluginFactory pluginFactory = new ImportClientPluginFactory(pluginConfiguration))
			{
				// Automatically pulls the RelativityVersion for the environment supplied in connectionInfo object
				Version relativityVersion = RetrieveRelativityVersion(connectionInfo);

				try
				{
					// Generally good idea to utilize try catch blocks
					IImportClient client = pluginFactory.CreateImportClient(relativityVersion, connectionInfo, context);
					ImportNativeDocs(client, datasetDirectory);
					ImportImages(client, datasetDirectory);
					Console.WriteLine(relativityVersion >= MinSdkVersion
						? "CONSOLE - SDK Import Completed."
						: "CONSOLE - Legacy Import Completed.");
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		private static void ImportNativeDocs(IImportClient client, string datasetDirectory)
		{
			using (DataTable table = new DataTable())
			{
				IBulkArtifactImportJob job = client.CreateNativeDocumentImportJob();
				table.Columns.Add("Control Number", typeof(string));
				table.Columns.Add("File Path", typeof(string));
				var fileNames = new List<string>
				{
					"EDRM-Sample1.pdf",
					"EDRM-Sample2.doc",
					"EDRM-Sample3.xlsx",
					"EDRM-Sample4.msg",
					"EDRM-Sample5.htm",
					"EDRM-Sample6.emf",
					"EDRM-Sample7.ppt",
					"EDRM-Sample9.txt"
				};

				Random random = new Random();
				int index = random.Next(1, fileNames.Count);
				string fileName = fileNames[index - 1];
				string controlNumber = GenerateControlNumber(fileName);
				table.Rows.Add(controlNumber, System.IO.Path.Combine(datasetDirectory, $"Docs\\{fileName}"));

				// Now setup the job.
				job.Settings.ArtifactTypeId = 10;
				job.Settings.CopyFilesToDocumentRepository = true;
				job.Settings.DisableControlNumberCompatibilityMode = false;
				job.Settings.DisableExtractedTextFileLocationValidation = false;
				job.Settings.DisableNativeValidation = false;
				job.Settings.DisableNativeLocationValidation = false;
				job.Settings.DisableUserSecurityCheck = true;
				job.Settings.ExtractedTextEncoding = Encoding.Unicode;
				job.Settings.ExtractedTextFieldContainsFilePath = false;
				job.Settings.IdentityFieldId = 1003667;
				job.Settings.MaximumErrorCount = int.MaxValue - 1;
				job.Settings.NativeFilePathSourceFieldName = "File Path";
				job.Settings.NativeFileCopyMode = "CopyFiles";
				job.Settings.OverlayBehavior = "MergeAll";
				job.Settings.OverwriteMode = "Append";
				job.Settings.StartRecordNumber = 0;
				job.DataSource = table.CreateDataReader();
				job.Execute();
			}
		}

		private static void ImportImages(IImportClient client, string datasetDirectory)
		{
			using (DataTable table = new DataTable())
			{
				IImageBulkArtifactImportJob job = client.CreateImageImportJob();
				table.Columns.Add("Bates Number", typeof(string));
				table.Columns.Add("Control Number", typeof(string));
				table.Columns.Add("File Location", typeof(string));
				var fileNames = new List<string>
				{
					"EDRM-Sample1.tif",
					"EDRM-Sample2.tif",
					"EDRM-Sample3.tif",
					"EDRM-Sample-000001.tif"
				};

				Random random = new Random();
				int index = random.Next(1, fileNames.Count);
				string fileName = fileNames[index - 1];
				string batesNumber = GenerateBatesNumber(fileName);
				string controlNumber = GenerateControlNumber(fileName);
				table.Rows.Add(batesNumber, controlNumber, System.IO.Path.Combine(datasetDirectory, $"Images\\{fileName}"));

				job.Settings.ArtifactTypeId = 10;
				job.Settings.AutoNumberImages = false;
				job.Settings.BatesNumberField = "Bates Number";
				job.Settings.CopyFilesToDocumentRepository = true;
				job.Settings.DisableImageLocationValidation = false;
				job.Settings.DisableImageTypeValidation = false;
				job.Settings.DisableUserSecurityCheck = true;
				job.Settings.DocumentIdentifierField = "Control Number";
				job.Settings.ExtractedTextEncoding = Encoding.Unicode;
				job.Settings.ExtractedTextFieldContainsFilePath = false;
				job.Settings.FileLocationField = "File Location";
				job.Settings.IdentityFieldId = 1003667;
				job.Settings.ImageFilePathSourceFieldName = "File Location";
				job.Settings.LoadImportedFullTextFromServer = false;
				job.Settings.MaximumErrorCount = int.MaxValue - 1;
				job.Settings.MoveDocumentsInAppendOverlayMode = false;
				job.Settings.NativeFileCopyMode = "CopyFiles";
				job.Settings.OverlayBehavior = "MergeAll";
				job.Settings.OverwriteMode = "Append";
				job.Settings.SelectedIdentifierFieldName = "Control Number";
				job.DataSource = table;
				job.Execute();
			}
		}

		private static string GenerateBatesNumber(string fileName)
		{
			return $"REL-BATES-{fileName.ToUpperInvariant()}-{Guid.NewGuid()}";
		}

		private static string GenerateControlNumber(string fileName)
		{
			return $"REL-{fileName.ToUpperInvariant()}-{Guid.NewGuid()}";
		}

		private static Version RetrieveRelativityVersion(ImportConnectionInfo connectionInfo)
		{
			try
			{
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(connectionInfo.WebServiceUrl.Replace("/RelativityWebApi/", ""));
				httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(connectionInfo.UserName + ":" + connectionInfo.Password)));
				httpClient.DefaultRequestHeaders.Add("X-CSRF-Header", string.Empty);
				var VersionEndpointUrl =
					"/relativity.rest/api/Relativity.Services.InstanceDetails.IInstanceDetailsModule/InstanceDetailsService/GetRelativityVersionAsync";
				var response = httpClient.PostAsync(VersionEndpointUrl, new StringContent(string.Empty, Encoding.UTF8, "application/json")).Result;
				response.EnsureSuccessStatusCode();
				string preFormatedVersion = response.Content.ReadAsStringAsync().Result;
				Version RelVersion = new Version(preFormatedVersion.Replace($"\"", ""));
				return RelVersion;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}