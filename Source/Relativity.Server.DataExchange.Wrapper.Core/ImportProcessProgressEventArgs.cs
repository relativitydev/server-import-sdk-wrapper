namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections;

	public sealed class ImportProcessProgressEventArgs : EventArgs
	{
		public ImportProcessProgressEventArgs(
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
			this.ProcessId = processId;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.TotalRecords = totalRecords;
			this.TotalRecordsProcessed = totalRecordsProcessed;
			this.TotalRecordsProcessedWithWarnings = totalRecordsProcessedWithWarnings;
			this.TotalRecordsProcessedWithErrors = totalRecordsProcessedWithErrors;
			this.MetadataThroughput = metadataThroughput;
			this.FilesThroughput = filesThroughput;
			this.StatusSuffixEntries = statusSuffixEntries;
		}

		public Guid ProcessId
		{
			get;
		}

		public DateTime StartTime
		{
			get;
		}

		public DateTime EndTime
		{
			get;
		}

		public long TotalRecords
		{
			get;
		}

		public long TotalRecordsProcessed
		{
			get;
		}

		public long TotalRecordsProcessedWithWarnings
		{
			get;
		}

		public long TotalRecordsProcessedWithErrors
		{
			get;
		}

		public IDictionary StatusSuffixEntries
		{
			get;
		}

		public double FilesThroughput
		{
			get;
		}

		public double MetadataThroughput
		{
			get;
		}
	}
}