namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections;

	[Serializable]
    public sealed class ImportContext
	{
		public event EventHandler<ImportCompleteEventArgs> Complete;
		public event EventHandler<ImportErrorEventArgs> Error;
		public event EventHandler<ImportFatalExceptionEventArgs> FatalException;
		public event EventHandler<ImportMessageEventArgs> Message;
		public event EventHandler<ImportProcessProgressEventArgs> ProcessProgress;
		public event EventHandler<ImportProgressEventArgs> Progress;

		public void PublishCompleted(
			long fileBytes,
			long metadataBytes,
			int totalRows,
			int errorRowCount,
			DateTime startTime,
			DateTime endTime)
		{
			this.Complete?.Invoke(this,
				new ImportCompleteEventArgs(fileBytes, metadataBytes, totalRows, errorRowCount, startTime, endTime));
		}

		public void PublishError(IDictionary row)
		{
			this.Error?.Invoke(this, new ImportErrorEventArgs(row));
		}

		public void PublishFatalException(
			Exception exception,
			long fileBytes,
			long metadataBytes,
			int totalRows,
			int errorRowCount,
			DateTime startTime,
			DateTime endTime)
		{
			this.FatalException?.Invoke(this,
				new ImportFatalExceptionEventArgs(exception, fileBytes, metadataBytes, totalRows, errorRowCount, startTime, endTime));
		}

		public void PublishMessage(string message)
		{
			this.Message?.Invoke(this, new ImportMessageEventArgs(message));
		}

		public void PublishProcessProgress(
			Guid processId,
			DateTime startTime,
			DateTime endTime,
			long totalRecords,
			long totalRecordsProcessed,
			long totalRecordsProcessedWithWarnings,
			long totalRecordsProcessedWithErrors,
			double metadataThroughput,
			double filesThroughput,
			IDictionary statusSuffixEntries)
		{
			ImportProcessProgressEventArgs args = new ImportProcessProgressEventArgs(
				processId,
				startTime,
				endTime,
				totalRecords,
				totalRecordsProcessed,
				totalRecordsProcessedWithWarnings,
				totalRecordsProcessedWithErrors,
				metadataThroughput,
				filesThroughput,
				statusSuffixEntries);
			this.ProcessProgress?.Invoke(this, args);
		}

		public void PublishProgress(long row)
		{
			this.Progress?.Invoke(this, new ImportProgressEventArgs(row));
		}
	}
}