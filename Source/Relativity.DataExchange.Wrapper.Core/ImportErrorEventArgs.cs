namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections;

	public sealed class ImportErrorEventArgs : EventArgs
	{
		public ImportErrorEventArgs(IDictionary row)
		{
			this.Row = row;
		}

		public IDictionary Row
		{
			get;
		}
	}
}