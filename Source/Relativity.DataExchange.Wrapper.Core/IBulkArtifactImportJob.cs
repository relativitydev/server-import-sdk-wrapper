namespace Relativity.Server.DataExchange.Wrapper
{
	using System.Data;

	/// <summary>
	/// Represents an import job to mass import document and object artifacts.
	/// Implements the <see cref="Relativity.DataExchange.Wrapper.IImportJob" />
	/// </summary>
	/// <seealso cref="Relativity.DataExchange.Wrapper.IImportJob" />
	public interface IBulkArtifactImportJob : IImportJob
	{
		/// <summary>
		/// Gets the job settings.
		/// </summary>
		/// <value>
		/// The <see cref="IBulkArtifactImportSettings"/> instance.
		/// </value>
		IBulkArtifactImportSettings Settings
		{
			get;
		}

		/// <summary>
		/// Gets the data source to import.
		/// </summary>
		/// <value>
		/// The <see cref="IDataReader"/> instance.
		/// </value>
		IDataReader DataSource
		{
			get;
			set;
		}
	}
}