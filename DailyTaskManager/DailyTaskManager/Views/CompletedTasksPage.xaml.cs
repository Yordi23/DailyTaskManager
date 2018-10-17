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
	public partial class CompletedTasksPage : ContentPage
	{
        public static ObservableCollection<string> CompletedTaskList = new ObservableCollection<string>();
        public CompletedTasksPage ()
		{
			InitializeComponent ();
            LoadActivities();
            CompletedListView.ItemsSource = CompletedTaskList;
            
        }

        public static void LoadActivities()
        {
            CompletedTaskList.Clear();

            using (var data = new DataAccess())
            {
                foreach (Activities item in data.GetActivitiesHistorial(true))
                {
                    CompletedTaskList.Add(item.Nombre);
                }
                data.Dispose();
            }
        }
    }
}