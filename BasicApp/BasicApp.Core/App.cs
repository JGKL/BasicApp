using BasicApp.Business.Factories;
using BasicApp.Business.Services;
using BasicApp.Core.Interfaces;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

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

            RegisterCustomAppStart<StartScreen>();

            // var platformInformation = Mvx.IoCProvider.Resolve<IPlatformInformation>();
            // Mvx.IoCProvider.RegisterSingleton<IDatabaseService>(new DatabaseService(new DatabaseSqLiteConnection(platformInformation.GetSQLitePlatform())));
        }
    }
}
