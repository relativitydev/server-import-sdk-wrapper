namespace Relativity.Server.DataExchange.Wrapper
{
	/// <summary>
	/// Represents an abstract client to create supported bulk artifact import jobs.
	/// </summary>
	public interface IImportClient
    {
		/// <summary>
		/// Creates the image import job.
		/// </summary>
		/// <returns>
		/// The <see cref="IImageBulkArtifactImportJob"/> instance.
		/// </returns>
		IImageBulkArtifactImportJob CreateImageImportJob();

		/// <summary>
		/// Creates the native document import job.
		/// </summary>
		/// <returns>
		/// The <see cref="IBulkArtifactImportJob"/> instance.
		/// </returns>
		IBulkArtifactImportJob CreateNativeDocumentImportJob();

		/// <summary>
		/// Creates the object import job.
		/// </summary>
		/// <returns>
		/// The <see cref="IBulkArtifactImportJob"/> instance.
		/// </returns>
		IBulkArtifactImportJob CreateObjectImportJob(int artifactTypeId);

		/// <summary>
		/// Creates the production import job.
		/// </summary>
		/// <returns>
		/// The <see cref="IImageBulkArtifactImportJob"/> instance.
		/// </returns>
		IImageBulkArtifactImportJob CreateProductionImportJob(int productionArtifactId);
    }
}