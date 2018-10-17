using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTaskManager.Views;
using DailyTaskManager.Services;
using Plugin.LocalNotifications;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DailyTaskManager
{
    
    public partial class App : Application
    {
        public static bool FirstExecution = false;
        public App()
        {
            InitializeComponent();

            //SqliteService sqlite = new SqliteService();
            
            if (Application.Current.Properties.ContainsKey("FirstUse"))
            {
                
            }
            else
            {
                Application.Current.Properties["FirstUse"] = false;
                FirstExecution = true;
                
            }
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
           
            
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            CrossLocalNotifications.Current.Show("Prueba", "Test 1");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        
    }
}
