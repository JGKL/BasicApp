using BasicApp.Business.Factories;
using BasicApp.Business.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using SQLite.Net.Interop;

namespace BasicApp
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("ServiceAgent").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes().EndingWith("Repository").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes().EndingWith("Repository").AsInterfaces().RegisterAsLazySingleton();

            var sqLitePlatform = Mvx.Resolve<ISQLitePlatform>();

            Mvx.RegisterSingleton<IDatabaseService>(new DatabaseService(new DatabaseSqLiteConnection(sqLitePlatform)));

            RegisterAppStart(new StartScreen());
        }
    }
}
