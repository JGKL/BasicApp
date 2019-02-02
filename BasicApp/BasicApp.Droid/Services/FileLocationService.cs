using System;
using System.IO;
using BasicApp.Interfaces;

namespace BasicApp.Droid.Services
{
    public class FileLocationService : IFileLocationService
    {
        private readonly string PersonalFolder;

        public FileLocationService()
        {
            PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        public bool FileExists(string filename)
        {
            return File.Exists(Path.Combine(PersonalFolder, filename));
        }

        public string GetDatabaseFilePath()
        {
            var sqliteFilename = "BasicApp.db3";
            var path = Path.Combine(PersonalFolder, sqliteFilename);
            return path;
        }

        public void CreateDatabaseFile()
        {

        }
    }
}