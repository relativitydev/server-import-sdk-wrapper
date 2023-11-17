namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Data;

	using kCura.Relativity.DataReaderClient;

	internal class BulkArtifactImportJob : ImportJobBase, IBulkArtifactImportJob
	{
		private readonly ImportBulkArtifactJob job;

		public BulkArtifactImportJob(
			ImportBulkArtifactJob job,
			ImportConnectionInfo connectionInfo,
			ImportContext context)
			: base(connectionInfo, context)
		{
			this.job = job ?? throw new ArgumentNullException(nameof(job));
			this.Settings = new BulkArtifactImportSettings(this.job.Settings)
			{
				WorkspaceId = this.ConnectionInfo.WorkspaceId
			};
		}

		public IDataReader DataSource
		{
			get => this.job.SourceData.SourceData;
			set => this.job.SourceData.SourceData = value;
		}

		public IBulkArtifactImportSettings Settings
		{
			get;
		}

		public override void Execute()
		{
			this.job.OnMessage += this.ImportJobOnMessage;
			this.job.OnComplete += this.ImportJobOnComplete;
			this.job.OnFatalException += this.ImportJobOnFatalException;
			this.job.OnError += this.ImportJobOnError;
			this.job.OnProgress += this.ImportJobOnProgress;
			this.job.OnProcessProgress += this.ImportJobOnProcessProgress;
			try
			{
				this.job.Execute();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}
	}
}