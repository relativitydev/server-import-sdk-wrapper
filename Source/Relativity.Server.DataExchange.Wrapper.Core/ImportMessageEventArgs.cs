namespace Relativity.Server.DataExchange.Wrapper
{
	using System;

	public sealed class ImportMessageEventArgs : EventArgs
	{
		public ImportMessageEventArgs(string message)
		{
			this.Message = message;
		}

		public string Message
		{
			get;
		}
	}
}