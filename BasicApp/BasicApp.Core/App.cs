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
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

            RegisterCustomAppStart<StartScreen>();
        }
    }
}
