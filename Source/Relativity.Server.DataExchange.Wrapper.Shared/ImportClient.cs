namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.ComponentModel.Composition;

	using kCura.Relativity.ImportAPI;

	[Export(typeof(IImportClient))]
	public class ImportClient : MarshalByRefObject, IImportClient
	{
		private readonly ImportConnectionInfo connectionInfo;
		private readonly ImportContext context;
		private ImportAPI instance;

		[ImportingConstructor]
		public ImportClient(
			[Import("ImportConnectionInfo")]
			ImportConnectionInfo connectionInfo,
			[Import("ImportContext")]
			ImportContext context)
		{
			this.connectionInfo = connectionInfo ?? throw new ArgumentNullException(nameof(connectionInfo));
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		IImageBulkArtifactImportJob IImportClient.CreateImageImportJob()
		{
			this.CreateInstance();
			return new ImageBulkArtifactImportJob(this.instance.NewImageImportJob(), this.connectionInfo, this.context);
		}

		IBulkArtifactImportJob IImportClient.CreateNativeDocumentImportJob()
		{
			this.CreateInstance();
			return new BulkArtifactImportJob(this.instance.NewNativeDocumentImportJob(), this.connectionInfo,
				this.context);
		}

		IBulkArtifactImportJob IImportClient.CreateObjectImportJob(int artifactTypeId)
		{
			this.CreateInstance();
			return new BulkArtifactImportJob(this.instance.NewObjectImportJob(artifactTypeId), this.connectionInfo,
				this.context);
		}

		IImageBulkArtifactImportJob IImportClient.CreateProductionImportJob(int productionArtifactId)
		{
			this.CreateInstance();
			return new ImageBulkArtifactImportJob(this.instance.NewProductionImportJob(productionArtifactId),
				this.connectionInfo,
				this.context);
		}

		private void CreateInstance()
		{
			if (this.instance != null)
			{
				return;
			}

			if (this.connectionInfo.UseRsaBearerToken)
			{
#if WRAPPER_SDK
				this.instance = ImportAPI.CreateByRsaBearerToken(this.connectionInfo.WebServiceUrl);
#else
				throw new NotSupportedException("This version of Import API doesn't support RSA bearer token authentication.");
#endif
			}
			else if (!string.IsNullOrEmpty(this.connectionInfo.UserName) &&
			    !string.IsNullOrEmpty(this.connectionInfo.Password))
			{
				this.instance = new ImportAPI(this.connectionInfo.UserName, this.connectionInfo.Password, this.connectionInfo.WebServiceUrl);
			}
			else
			{
#if WRAPPER_SDK
				throw new NotSupportedException("This version of Import API doesn't support integrated security authentication.");
#else
				this.instance = new ImportAPI(this.connectionInfo.WebServiceUrl);
#endif
			}
		}
	}
}