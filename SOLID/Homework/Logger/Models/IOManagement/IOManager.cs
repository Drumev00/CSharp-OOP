using System.IO;

using Logger.Models.Contracts;

namespace Logger.Models.IOManagement
{
	public class IOManager : IIOManager
	{
		private string currentPath;
		private string currentDirectory;
		private string currentFile;
		private IOManager()
		{
			this.currentPath = GetCurrentPath();
		}
		public IOManager(string currentDirectory, string currentFile)
			:this()
		{
			this.currentDirectory = currentDirectory;
			this.currentFile = currentFile;
		}
		public string DirectoryPath => this.currentPath + this.currentDirectory;

		public string FilePath => DirectoryPath + this.currentFile;

		public void EnsureExistence()
		{
			if (!Directory.Exists(this.DirectoryPath))
			{
				Directory.CreateDirectory(this.DirectoryPath);
			}
			File.WriteAllText(this.FilePath, "");
		}

		public string GetCurrentPath()
		{
			return Directory.GetCurrentDirectory();
		}
	}
}
