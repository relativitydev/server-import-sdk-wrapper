namespace Relativity.Server.DataExchange.Wrapper
{
	using System;

	/// <summary>
	/// Represents a factory to create <see cref="IImportClient"/> instances.
	/// Implements the <see cref="System.IDisposable" />
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	/// <remarks>
	/// The construction of each <see cref="IImportClient"/> should be wrapped with this object to guarantee assembly isolation.
	/// </remarks>
	public sealed class ImportClientPluginFactory : IDisposable
	{
		private readonly PluginConfiguration configuration;
		private ImportClientPluginSearch pluginSearch;
		private bool disposed;

		/// <summary>
		/// Initializes a new instance of the <see cref="ImportClientPluginFactory"/> class.
		/// </summary>
		/// <param name="configuration">
		/// The plugin configuration.
		/// </param>
		public ImportClientPluginFactory(PluginConfiguration configuration)
		{
			this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			this.pluginSearch = null;
			this.disposed = false;
		}

		/// <summary>
		/// Creates an import client that's compatible with the Relativity instance defined by <paramref name="connectionInfo"/>.
		/// </summary>
		/// <param name="relativityVersion">
		/// The Relativity version that was retrieved by REST API.
		/// </param>
		/// <param name="connectionInfo">
		/// The import connection information.
		/// </param>
		/// <param name="context">
		/// The import context.
		/// </param>
		/// <returns>
		/// The <see cref="IImportClient"/> instance.
		/// </returns>
		/// <remarks>
		/// The async/await pattern cannot be used because none of the constructs are marked with <see cref="SerializableAttribute"/>.
		/// </remarks>
		/// <exception cref="NotSupportedException">Thrown when there is an attempt to create an unsupported client</exception>
		public IImportClient CreateImportClient(
			Version relativityVersion,
			ImportConnectionInfo connectionInfo,
			ImportContext context)
		{
			this.Initialize();
			// We can add a flag here to state we'll only allow construction of one or the other, but never both
			return this.pluginSearch.CreateImportClient(relativityVersion, connectionInfo, context);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Ensure the plugin search object is properly initialized.
		/// </summary>
		private void Initialize()
		{
			if (this.pluginSearch != null)
			{
				return;
			}

			this.pluginSearch = new ImportClientPluginSearch();

			this.pluginSearch.Initialize(configuration);

		}

		private void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					if (this.pluginSearch != null)
					{
						this.pluginSearch.Dispose();
						this.pluginSearch = null;
					}
				}

				this.disposed = true;
			}
		}
	}
}