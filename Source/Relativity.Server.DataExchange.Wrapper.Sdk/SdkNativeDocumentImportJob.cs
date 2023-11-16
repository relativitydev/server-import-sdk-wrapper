namespace Relativity.Sample.Agent.Sdk
{
	using System;
	using System.Collections.Generic;
	using System.Data;

	using kCura.Relativity.DataReaderClient;
	using kCura.Relativity.ImportAPI;
	using Relativity.Sample.Agent.Core;

	internal class SdkNativeDocumentImportJob : ImportJobBase
	{
		private const string SampleDocPdfFileName = "EDRM-Sample1.pdf";
		private const string SampleDocWordFileName = "EDRM-Sample2.doc";
		private const string SampleDocExcelFileName = "EDRM-Sample3.xlsx";
		private const string SampleDocMsgFileName = "EDRM-Sample4.msg";
		private const string SampleDocHtmFileName = "EDRM-Sample5.htm";
		private const string SampleDocEmfFileName = "EDRM-Sample6.emf";
		private const string SampleDocPptFileName = "EDRM-Sample7.ppt";
		private const string SampleDocTxtFileName = "EDRM-Sample9.txt";
		private static readonly Random random = new Random();
		private readonly ImportClientConfiguration configuration;

		public SdkNativeDocumentImportJob(ImportClientConfiguration configuration)
			: base(configuration)
		{
		}

		public override void Execute()
		{
			DataTable table = new DataTable();
			table.Columns.Add("Control Number", typeof(string));
			table.Columns.Add("File Path", typeof(string));
			var filenames = new List<string>
			{
				SampleDocPdfFileName,
				SampleDocWordFileName,
				SampleDocExcelFileName,
				SampleDocMsgFileName,
				SampleDocHtmFileName,
				SampleDocEmfFileName,
				SampleDocPptFileName,
				SampleDocTxtFileName
			};

			int index = random.Next(1, filenames.Count);
			string fileName = filenames[index - 1];
			string controlNumber = GenerateControlNumber(fileName);
			table.Rows.Add(controlNumber, System.IO.Path.Combine(@"S:\Samples - Relativity\IntAuthIAPIAgent - Sample\ImportAPI-Agent-Plugin\Dataset\Docs", fileName));

			ImportAPI iapi = new ImportAPI(this.configuration.UserName, this.configuration.Password, this.configuration.WebServiceUrl);
			var importJob = iapi.NewNativeDocumentImportJob();
			importJob.OnMessage += status =>
			{
				// Handle messages here or raise some event.
				System.Diagnostics.Trace.TraceInformation($"Message: {status.Message}");
			};

			importJob.OnComplete += report =>
			{
				// Handle completion here or raise some event.
				System.Diagnostics.Trace.TraceInformation($"Job finished with {report.ErrorRowCount} errors.");
			};

			importJob.OnFatalException += report =>
			{
				// Handle fatal exceptions here or raise some event.
				System.Diagnostics.Trace.TraceError($"Job fatal error: {report.FatalException}.");
			};

			importJob.Settings.CaseArtifactId = this.configuration.WorkspaceId;
			importJob.Settings.ExtractedTextFieldContainsFilePath = false;
			importJob.Settings.NativeFileCopyMode = NativeFileCopyModeEnum.CopyFiles;
			importJob.Settings.NativeFilePathSourceFieldName = "File Path";
			importJob.Settings.OverwriteMode = OverwriteModeEnum.Append;
			importJob.Settings.IdentityFieldId = this.configuration.IdentifyFieldArtifactId;
			importJob.SourceData.SourceData = table.CreateDataReader();
			importJob.Execute();
		}

		private static string GenerateControlNumber(string fileName)
		{
			return $"REL-{fileName.ToUpperInvariant()}-{Guid.NewGuid()}";
		}
	}
}