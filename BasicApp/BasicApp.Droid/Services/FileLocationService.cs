using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BasicApp.Business.Enum;
using BasicApp.Interfaces;

namespace BasicApp.Droid.Services
{
    public class FileLocationService : IFileLocationService
    {
        /// <summary>
        /// The personal folder.
        /// </summary>
        private readonly string PersonalFolder;

        /// <summary>
        /// Initializes a new instance of the FileLocation class.
        /// </summary>
        public FileLocationService()
        {
            PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        public string GetDatabaseFilePath(string filename)
        {
            var filePath = Path.Combine(PersonalFolder, filename);
            return filePath;
        }

        public void SaveFile(FileType fileType, string filename, Stream stream)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(FileType fileType, string filename)
        {
            throw new NotImplementedException();
        }

        public void OpenFile(FileType fileType, string fileName)
        {
            throw new NotImplementedException();
        }

        public Stream GetFile(FileType fileType, string fileName)
        {
            var filePath = FindDirectory(fileName, fileType);
            var fileReadStream = File.OpenRead(filePath);

            return fileReadStream;
        }

        public List<string> GetFiles(FileType fileType)
        {
            throw new NotImplementedException();
        }

        public bool FileExists(FileType fileType, string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the directory.
        /// </summary>
        /// <returns>The directory.</returns>
        /// <param name="filename">Filename.</param>
        /// <param name="fileType">File type.</param>
        private string FindDirectory(string filename, FileType fileType)
        {
            var folder = GetDirectoryByFileType(fileType);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var filePath = Path.Combine(folder, filename);
            var dirPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            return filePath;
        }

        /// <summary>
        /// Gets the directory by file type.
        /// </summary>
        /// <returns>The directory by file type.</returns>
        /// <param name="fileType">File type.</param>
        private string GetDirectoryByFileType(FileType fileType)
        {
            return PersonalFolder;
        }

        /// <summary>
        /// Checks if the directory is empty.
        /// </summary>
        /// <returns><c>true</c>, if directory is empty, <c>false</c> otherwise.</returns>
        /// <param name="path">Path.</param>
        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}