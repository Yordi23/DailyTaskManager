using DailyTaskManager.Models;
using DailyTaskManager.Models.DB;
using DailyTaskManager.Services.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReminderPage : ContentPage
	{
        ObservableCollection<string> activitiesName = new ObservableCollection<string>();
        ObservableCollection<string> CurrentFreeTimes = new ObservableCollection<string>();

        public ReminderPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            string dia;
            dia = DateTime.Now.ToString("dddd") + " " + DateTime.Today.Day.ToString();
            lblDate.Text = dia + ", " + DateTime.Now.ToString("MMMM");
            LoadActivities();
            LoadHour();
            ActivitiesList.ItemsSource = activitiesName;
            FreeTimeList.ItemsSource = CurrentFreeTimes;
        }
        public void LoadActivities()
        {
            activitiesName.Clear();
            ActivitiesList.ItemsSource = null;
            using (var data = new DataAccess())
            {
                
                foreach (Activities item in data.GetActivities())
                {
                    activitiesName.Add(item.Nombre);
                }
            }
            
        }
        public void LoadHour()
        {
            string todayDay = DateTime.Now.ToString("dddd");
            using (var data = new DataAccess())
            {
                List<FreeTime> times = data.GetFreeTime(todayDay);
                
                foreach (FreeTime item in times)
                {
                    string initialTime, endtime,time;
                    double initialH, endH;
                    int initialM, endM;
                    initialH = Math.Truncate(double.Parse((item.StartTime / 60).ToString()));
                    initialM = int.Parse((item.StartTime % 60).ToString());
                    
                    endH = Math.Truncate(double.Parse((item.EndTime / 60).ToString()));
                    endM = int.Parse((item.EndTime % 60).ToString());
                    if (initialH >= 12)
                    {
                        initialH -= 12;
                        if (initialM < 10)
                        {
                            initialTime = initialH + ":" + "0" + initialM + " PM";
                        }
                        else
                        {
                            initialTime = initialH + ":" + initialM + " PM";
                        }
                    }
                    else
                    {
                        if (initialM < 10)
                        {
                            initialTime = initialH + ":" + "0" + initialM + " AM";
                        }
                        else
                        {
                            initialTime = initialH + ":" + initialM + " AM";
                        }
                       
                    }
                    if (endH >= 12)
                    {
                        endH -= 12;

                        if (endM < 10)
                        {
                            endtime = endH + ":" + "0" + endM + " PM";
                        }
                        else
                        {
                            endtime = endH + ":" + endM + " PM";
                        }
                        
                    }
                    else
                    {
                        if (endM < 10)
                        {
                            endtime = endH + ":" + "0" + endM + " AM";
                        }
                        else
                        {
                            endtime = endH + ":" + endM + " AM";
                        }
                    }                 
                    time = initialTime + "-" + endtime;
                    CurrentFreeTimes.Add(time);
                }
            }

        }
	}
}