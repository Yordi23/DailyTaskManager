using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DailyTaskManager.Services.Sqlite;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DailyTaskManager.iOS.Config))]

namespace DailyTaskManager.iOS
{
    class Config : IConfig
    {
        private string DirectoryDB;

        public SQLiteConnection Connection {
            get
            {
                string location = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                string direction = Path.Combine(location, "..", "Library", "DAGDB.db3");
                SQLiteConnection con = new SQLiteConnection(direction);
                return con;
            }
        }
    }
}