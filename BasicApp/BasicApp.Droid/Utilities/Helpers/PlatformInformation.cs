using SQLite.Net.Interop;
using BasicApp.Core.Interfaces;
using SQLite.Net.Platform.XamarinAndroid;

namespace BasicApp.Droid.Utilities.Helpers
{
    public class PlatformInformation : IPlatformInformation
    {
        public ISQLitePlatform GetSQLitePlatform()
        {
            return new SQLitePlatformAndroid();
        }
    }
}