namespace Logger.Models.Contracts
{
	public interface IIOManager
	{
		string DirectoryPath { get; }
		string FilePath { get; }
		void EnsureExistence();
		string GetCurrentPath();
	}
}
