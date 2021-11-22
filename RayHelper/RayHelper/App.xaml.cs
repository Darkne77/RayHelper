using System;
using MvvmCross;
using MvvmCross.IoC;
using RayHelper.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace RayHelper
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Initialize MVVMCross Dependency Container 
            MvxIoCProvider.Initialize();
            RegisterDependencies();
            
            MainPage = new LoginPage();
        }

        private void RegisterDependencies()
        {
            Mvx.IoCProvider.RegisterSingleton(new AuthorizationService());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}