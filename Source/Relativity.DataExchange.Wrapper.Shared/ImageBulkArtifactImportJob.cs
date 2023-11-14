namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Data;

	using kCura.Relativity.DataReaderClient;

	internal class ImageBulkArtifactImportJob : ImportJobBase, IImageBulkArtifactImportJob
	{
		private readonly ImageImportBulkArtifactJob job;

		public ImageBulkArtifactImportJob(
			ImageImportBulkArtifactJob job,
			ImportConnectionInfo connectionInfo,
			ImportContext context)
			: base(connectionInfo, context)
		{
			this.job = job ?? throw new ArgumentNullException(nameof(job));
			this.Settings = new ImageBulkArtifactImportSettings(this.job.Settings)
			{
				WorkspaceId = this.ConnectionInfo.WorkspaceId
			};
		}

		public DataTable DataSource
		{
			get => this.job.SourceData.SourceData;
			set => this.job.SourceData.SourceData = value;
		}

		public IImageBulkArtifactImportSettings Settings
		{
			get;
		}

		public override void Execute()
		{
			this.job.OnComplete += this.ImportJobOnComplete;
			this.job.OnError += ImportJobOnError;
			this.job.OnFatalException += this.ImportJobOnFatalException;
			this.job.OnMessage += this.ImportJobOnMessage;
			this.job.OnProgress += this.ImportJobOnProgress;
			this.job.Execute();
		}
	}
}