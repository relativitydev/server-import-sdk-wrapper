namespace Relativity.Server.DataExchange.Wrapper
{
	/// <summary>
	/// Represents an abstract import job.
	/// </summary>
	public interface IImportJob
	{
		/// <summary>
		/// Executes the import job.
		/// </summary>
		void Execute();
    }
}