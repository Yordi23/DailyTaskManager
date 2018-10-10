using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DailyTaskManager.Services.Sqlite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DailyTaskManager.Droid.Config))]

namespace DailyTaskManager.Droid
{
    class Config : IConfig
    {

        public SQLiteConnection Connection
        {
            get
            {
                string location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string direction = Path.Combine(location, "DAGDB.db3");
                SQLiteConnection con = new SQLiteConnection(direction,true);
                return con;
            }
        }
    }
}