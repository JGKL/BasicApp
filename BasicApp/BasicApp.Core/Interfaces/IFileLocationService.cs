namespace BasicApp.Interfaces
{
    public interface IFileLocationService
    {
        string GetDatabaseFilePath();
        bool FileExists(string filename);
    }
}
