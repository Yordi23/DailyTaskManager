using DailyTaskManager.Models.DB;
using DailyTaskManager.Services.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
    {
        static int TotalTask = 0, CompletedTask = 0, DeleyedTask = 0;
        static decimal Permonce = 100;
        static string Name = "User", LastName = "", TCTask = "0", TDTask = "0", StringPerformance = "100";
        static ImageSource ProfilePicture = null;

        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            string dia;
            dia = DateTime.Now.ToString("dddd") + " " + DateTime.Today.Day.ToString();
            lblDate.Text = dia + ", " + DateTime.Now.ToString("MMMM");
            
            MessagingCenter.Subscribe<MainPage>(this, "UpdateHome", (arg) => {
                LoadUserProfile();
                Reset();
            });
        }
        private void Reset()
        {
            lblUserLastName.Text = LastName;
            lblUserName.Text = Name;
            ImageBox.Source = ProfilePicture;

            lblCompletedTasks.Text = TCTask;
            lblDelayedTasks.Text = TDTask;
            lblPerformance.Text = StringPerformance;
        }
        public static void LoadUserProfile()
        {
            try
            {
                using (var data = new DataAccess())
                {
                    User us = data.GetUser();
                    ProfilePicture = ImageSource.FromStream(() => new MemoryStream(us.Image));
                    LastName = us.LastName;
                    Name = us.Name;

                    CompletedTask = data.GetActivities(true).Count;
                    DeleyedTask = data.GetActivities(false).Count;
                    TotalTask = data.GetActivities().Count;
                    Permonce = ((decimal) CompletedTask / (decimal)TotalTask) * 100;

                    TCTask = string.Format("{0}/{1}", CompletedTask, TotalTask);
                    TDTask = string.Format("{0}/{1}", DeleyedTask, TotalTask);
                    StringPerformance = string.Format("{0}%", Math.Round(Permonce));
                    data.Dispose();
                }
            }
            catch
            {

            }
        }
    }
}