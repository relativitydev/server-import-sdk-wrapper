namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections;

	using kCura.Relativity.DataReaderClient;

	internal abstract class ImportJobBase : MarshalByRefObject, IImportJob
	{
		private readonly ImportContext context;

		protected ImportJobBase(
			ImportConnectionInfo connectionInfo,
			ImportContext context)
		{
			this.ConnectionInfo = connectionInfo ?? throw new ArgumentNullException(nameof(connectionInfo));
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		protected ImportConnectionInfo ConnectionInfo
		{
			get;
		}

		public abstract void Execute();

		protected void ImportJobOnComplete(JobReport jobReport)
		{
			this.context.PublishCompleted(
				jobReport.FileBytes,
				jobReport.MetadataBytes,
				jobReport.TotalRows,
				jobReport.ErrorRowCount,
				jobReport.StartTime,
				jobReport.EndTime);
		}

		protected void ImportJobOnError(IDictionary row)
		{
			this.context.PublishError(row);
		}

		protected void ImportJobOnFatalException(JobReport jobReport)
		{
		
			this.context.PublishFatalException(
				jobReport.FatalException,
				jobReport.FileBytes,
				jobReport.MetadataBytes,
				jobReport.TotalRows,
				jobReport.ErrorRowCount,
				jobReport.StartTime,
				jobReport.EndTime);
		}

		protected void ImportJobOnMessage(Status status)
		{
			this.context.PublishMessage(status.Message);
		}

		protected void ImportJobOnProgress(long row)
		{
			this.context.PublishProgress(row);
		}

		protected void ImportJobOnProcessProgress(FullStatus status)
		{
			this.context.PublishProcessProgress(
				status.ProcessID,
				status.StartTime,
				status.EndTime,
				status.TotalRecords,
				status.TotalRecordsProcessed,
				status.TotalRecordsProcessedWithWarnings,
				status.TotalRecordsProcessedWithErrors,
				status.MetadataThroughput,
				status.FilesThroughput,
				status.StatusSuffixEntries);
		}
	}
}