using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DailyTaskManager.Services.Sqlite;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(DailyTaskManager.Droid.Config))]

namespace DailyTaskManager.Droid
{
    class Config : IConfig
    {
        private string DirectoryDB;
        private ISQLitePlatform platform;

        public string DBDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(DirectoryDB)){
                    DirectoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return DirectoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return platform;
            }
        }
    }
}