using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTaskManager.Views;
using DailyTaskManager.Services;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DailyTaskManager
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            MainPage = new MainPage();
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
