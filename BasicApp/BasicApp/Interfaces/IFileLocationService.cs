using System.Collections.Generic;
using System.IO;
using BasicApp.Business.Enum;

namespace BasicApp.Interfaces
{
    /// <summary>
    /// Interface is used for OS specific behaviour
    /// </summary>
    public interface IFileLocationService
    {
        /// <summary>
        /// Gets the database local file path.
        /// </summary>
        /// <returns>The database local file path.</returns>
        /// <param name="filename">Filename.</param>
        string GetDatabaseFilePath(string filename);

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="fileType">File type.</param>
        /// <param name="filename">Filename.</param>
        /// <param name="stream">Stream.</param>
        void SaveFile(FileType fileType, string filename, Stream stream);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="fileType">File type.</param>
        /// <param name="filename">Filename.</param>
        void DeleteFile(FileType fileType, string filename);

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="fileType">File type.</param>
        /// <param name="fileName">File name.</param>
        void OpenFile(FileType fileType, string fileName);

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="fileType">File type.</param>
        /// <param name="fileName">File name.</param>
        Stream GetFile(FileType fileType, string fileName);

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns>The files.</returns>
        /// <param name="fileType">File type.</param>
        List<string> GetFiles(FileType fileType);

        /// <summary>
        /// Checks if file exists.
        /// </summary>
        /// <returns><c>true</c>, if file exists, <c>false</c> otherwise.</returns>
        /// <param name="fileType">File type.</param>
        /// <param name="fileName">File name.</param>
        bool FileExists(FileType fileType, string fileName);
    }
}
