using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DailyTaskManager.Services.Sqlite;
using Foundation;
using SQLite.Net.Interop;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DailyTaskManager.iOS.Config))]

namespace DailyTaskManager.iOS
{
    class Config : IConfig
    {
        private string DirectoryDB;
        private ISQLitePlatform platform;
        public string DBDirectory
        {
            get
            {
                if(string.IsNullOrEmpty(DirectoryDB)){
                    var direct = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    DirectoryDB = System.IO.Path.Combine(direct, "..", "Library");
                }
                return DirectoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if(platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return platform;
            }
        }

    }
}