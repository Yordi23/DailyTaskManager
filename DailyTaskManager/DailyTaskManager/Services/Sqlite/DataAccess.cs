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
            try
            {
                connection.CreateTable<User>();
            }
            catch
            {

            }
            try
            {
                connection.CreateTable<FreeTime>();
            }
            catch
            {

            }
            try
            {
                connection.CreateTable<Rules>();
            }
            catch
            {

            }
            try
            {
                connection.CreateTable<Activities>();
            }
            catch
            {

            }
            
            
            
            
        }

        public void Insert(Object act)
        {
            connection.Insert(act);
        }

        public void Update(Object act)
        {
            connection.Update(act);
        }

        public void Delete(Object act)
        {
            connection.Delete(act);
        }
        //Activity

        public Activities GetActivity(int idActv)
        {
            return connection.Table<Activities>().FirstOrDefault(a => a.Id == idActv);
        }

        public List<Activities> GetActivities()
        {
            return connection.Table<Activities>().OrderBy(c => c.Fecha).ToList();
        }
        public List<Activities> GetActivities(bool pendent)
        {
            return connection.Table<Activities>().Where(a => a.Pendiente != pendent).ToList();
        }

        //Rule

        public Rules GetRule(int idActv,int idRule)
        {
            return connection.Table<Rules>().FirstOrDefault(a => a.BindId == idActv && a.Id == idRule);
        }

        public List<Rules> GetRules(int idActv)
        {
            return connection.Table<Rules>().Where(a => a.BindId == idActv).ToList();
        }
        
        //Time

        public List<FreeTime> GetFreeTime(string day)
        {
            return connection.Table<FreeTime>().Where(a => a.Day == day).ToList();
        }

        public List<FreeTime> GetFreeTime()
        {
            return connection.Table<FreeTime>().OrderBy(c => c.Day).ToList();
        }

        //User
        public List<User> GetUsers()
        {
            return connection.Table<User>().ToList();
        }
        public User GetUser()
        {
            return connection.Table<User>().FirstOrDefault();
        }
        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
