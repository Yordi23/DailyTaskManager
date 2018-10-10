using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using DailyTaskManager.Models;
using System.Linq;
using DailyTaskManager.Models.DB;

namespace DailyTaskManager.Services.Sqlite
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Platform, Path.Combine(config.DBDirectory, "DAGDB.db3"));
            connection.CreateTable<Activities>();
            connection.CreateTable<Rules>();
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

        public void UpdateRule(Activities act)
        {
            connection.Update(act);
        }

        public void DeleteRule(Activities act)
        {
            connection.Delete(act);
        }

        public RulesModel GetRule(int idActv,int idRule)
        {
            return connection.Table<RulesModel>().FirstOrDefault(a => a.BindId == idActv && a.Id == idRule);
        }

        public List<RulesModel> GetRules(int idActv)
        {
            return connection.Table<RulesModel>().Where(a => a.BindId == idActv).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
