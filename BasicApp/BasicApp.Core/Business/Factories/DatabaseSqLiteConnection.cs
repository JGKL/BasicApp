using BasicApp.Interfaces;
using MvvmCross;
using SQLite.Net;
using SQLite.Net.Interop;

namespace BasicApp.Business.Factories
{
    public interface ISQLiteConnection
    {
        SQLiteConnection CreateConnection();
    }

    public class DatabaseSqLiteConnection : ISQLiteConnection
    {
        private readonly ISQLitePlatform _platform;

        public DatabaseSqLiteConnection(ISQLitePlatform platform)
        {
            _platform = platform;
        }

        public SQLiteConnection CreateConnection()
        {
            var location = Mvx.IoCProvider.Resolve<IFileLocationService>();
            return new SQLiteConnection(_platform, location.GetDatabaseFilePath("BasicApp.db3"));
        }
    }
}
