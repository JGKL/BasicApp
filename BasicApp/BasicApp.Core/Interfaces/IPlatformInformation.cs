using SQLite.Net.Interop;

namespace BasicApp.Core.Interfaces
{
    public interface IPlatformInformation
    {
        ISQLitePlatform GetSQLitePlatform();
    }
}
