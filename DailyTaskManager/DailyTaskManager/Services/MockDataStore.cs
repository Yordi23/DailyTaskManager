using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DailyTaskManager.Models;
using DailyTaskManager.Models.DB;
using DailyTaskManager.Services.Sqlite;

namespace DailyTaskManager.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        ObservableCollection<Item> items;

        public MockDataStore()
        {
            items = new ObservableCollection<Item>();
            //SqliteService sqlite = new SqliteService();
            List<Activities> mockItems = new List<Activities>();
            List<Rules> RulesList = new List<Rules>();
            using (var data = new DataAccess())
            {
                mockItems = data.GetActivities();
            }
            foreach (var activity in mockItems)
            {
                using (var data = new DataAccess())
                {
                    RulesList = data.GetRules(activity.Id);
                }
                Item it = new Item(activity.Id,activity.RowId, (bool)activity.Pendiente,activity.Nombre, activity.Descripcion, activity.Lugar,activity.Fecha,(int) activity.Hora, RulesList, (byte)activity.Prioridad);
                items.Add(it);
            }

        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            Console.WriteLine(items.Count);
            var oldItem = items.Where((Item arg) => arg.Id.ToString() == id).FirstOrDefault();
            Console.WriteLine(oldItem.GetID());
            items.Remove(oldItem);
            Console.WriteLine(items.Count);
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id.ToString() == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}