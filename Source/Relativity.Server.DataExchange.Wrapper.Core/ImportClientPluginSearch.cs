namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.Composition;
	using System.ComponentModel.Composition.Hosting;
	using System.Linq;

	internal class ImportClientPluginSearch : MarshalByRefObject, IDisposable
	{
		/// <summary>
		/// The SDK is compatible with Relativity bluestem3 (and all hotfixes) on forward.
		/// </summary>
		private static readonly Version MinSdkVersion = new Version(9, 7, 229, 5);
		private bool disposed;
		private DirectoryCatalog catalog;
		private CompositionContainer container;
		private PluginConfiguration pluginConfiguration;
		private static string previousPluginDirectory;

		public ImportClientPluginSearch()
		{
			this.ImportClients = new List<Lazy<IImportClient>>();
		}

		[ImportMany(typeof(IImportClient))]
		private IList<Lazy<IImportClient>> ImportClients
		{
			get;
			set;
		}

		public void Initialize(PluginConfiguration configuration)
		{
			this.pluginConfiguration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		public IImportClient CreateImportClient(Version relativityVersion, ImportConnectionInfo connectionInfo,
			ImportContext context)
		{
			string pluginDirectory = relativityVersion >= MinSdkVersion
				? this.pluginConfiguration.SdkPluginDirectory
				: this.pluginConfiguration.LegacyPluginDirectory;
			if (!string.IsNullOrEmpty(previousPluginDirectory) &&
				string.Compare(pluginDirectory, previousPluginDirectory, StringComparison.OrdinalIgnoreCase) != 0)
			{
				throw new NotSupportedException("There was an attempt to create different versioned Import API clients in the same app domain. This is unsupported.");
			}
			previousPluginDirectory = pluginDirectory;
			return this.FindClient(pluginDirectory, connectionInfo, context);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					if (this.container != null)
					{
						this.container.Dispose();
						this.container = null;
					}

					if (this.catalog != null)
					{
						this.catalog.Dispose();
						this.catalog = null;
					}
				}

				this.disposed = true;
			}
		}

		private IImportClient FindClient(
			string pluginDirectory,
			ImportConnectionInfo connectionInfo,
			ImportContext context)
		{

			container?.Dispose();
			catalog?.Dispose();
			// We can add logic here to check for multiple constructions of the import client from the same app domain,
			// but with different version requests. Compare the plugin directory that was passed in, against a static plugin 
			// directory variable -----------------NOTE - is this not already happening in the calling method?

			// Note: You MUST use a specific enough filename filter for your plugins and prevent MEF from trying
			//       to do things like load native binaries.
			this.catalog = new DirectoryCatalog(pluginDirectory, "Relativity.Server.DataExchange.Wrapper.*.dll");
			this.container = new CompositionContainer(catalog);
			this.ImportClients.Clear();
			container.ComposeExportedValue("ImportConnectionInfo", connectionInfo);
			container.ComposeExportedValue("ImportContext", context);
			container.ComposeParts(this);
			if (this.ImportClients.Count == 0)
			{
				throw new InvalidOperationException(
					"The import cannot be completed because no plugins were discovered.");
			}

			List<Lazy<IImportClient>> candidates = this.ImportClients.ToList();
			if (candidates.Count > 1)
			{
				throw new InvalidOperationException(
					"The import cannot be completed because more than 1 plugin was discovered.");
			}

			IImportClient client = candidates[0].Value;
			return client;
		}
	}
}