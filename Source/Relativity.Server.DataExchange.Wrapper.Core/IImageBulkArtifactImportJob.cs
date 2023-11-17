namespace Relativity.Server.DataExchange.Wrapper
{
	using System.Data;

	/// <summary>
	/// Represents an import job to mass import image or production-based artifacts.
	/// Implements the <see cref="Relativity.Server.DataExchange.Wrapper.IImportJob" />
	/// </summary>
	/// <seealso cref="Relativity.Server.DataExchange.Wrapper.IImportJob" />
	public interface IImageBulkArtifactImportJob : IImportJob
	{
		/// <summary>
		/// Gets the job settings.
		/// </summary>
		/// <value>
		/// The <see cref="IImageBulkArtifactImportSettings"/> instance.
		/// </value>
		IImageBulkArtifactImportSettings Settings
		{
			get;
		}

		/// <summary>
		/// Gets the data source to import.
		/// </summary>
		/// <value>
		/// The <see cref="DataTable"/> instance.
		/// </value>
		DataTable DataSource
		{
			get;
			set;
		}
	}
}