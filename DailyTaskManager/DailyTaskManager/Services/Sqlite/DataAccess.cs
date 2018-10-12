using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using DailyTaskManager.Models;
using System.Linq;
using DailyTaskManager.Models.DB;
using SQLite;

namespace DailyTaskManager.Services.Sqlite
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            //SQLiteConnectionString cString = new SQLiteConnectionString(,storeDateTimeAsTicks:true);
            connection = DependencyService.Get<IConfig>().Connection;
            connection.CreateTable<Activities>();
            connection.CreateTable<Rules>();
            connection.CreateTable<FreeTime>();
            connection.CreateTable<User>();
        }

        public void InsertActvity(Activities act)
        {
            connection.Insert(act);
        }

        public void UpdateActivity(Activities act)
        {
            connection.Update(act);
        }

        public void DeleteActivity(Activities act)
        {
            connection.Delete(act);
        }

        public Activities GetActivity(int idActv)
        {
            return connection.Table<Activities>().FirstOrDefault(a => a.Id == idActv);
        }

        public List<Activities> GetActivities()
        {
            return connection.Table<Activities>().OrderBy(c => c.Fecha).ToList();
        }

        public void InsertRule(Rules rul)
        {
            connection.Insert(rul);
        }

        public void UpdateRule(Rules act)
        {
            connection.Update(act);
        }

        public void DeleteRule(Rules act)
        {
            connection.Delete(act);
        }

        public Rules GetRule(int idActv,int idRule)
        {
            return connection.Table<Rules>().FirstOrDefault(a => a.BindId == idActv && a.Id == idRule);
        }

        public List<Rules> GetRules(int idActv)
        {
            return connection.Table<Rules>().Where(a => a.BindId == idActv).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
