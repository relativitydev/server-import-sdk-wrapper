namespace Relativity.Server.DataExchange.Wrapper
{
	using System;

	public sealed class ImportProgressEventArgs : EventArgs
	{
		public ImportProgressEventArgs(long row)
		{
			this.Row = row;
		}

		public long Row
		{
			get;
		}
	}
}