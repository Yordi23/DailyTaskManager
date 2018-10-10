using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyTaskManager.Models;
using DailyTaskManager.Models.Sqlite;

namespace DailyTaskManager.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            SqliteService sqlite = new SqliteService();
            var mockItems = new List<Item>(){
                new Item(),new Item(),new Item()
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }

        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.RowId == item.RowId).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            Console.WriteLine(items.Count);
            var oldItem = items.Where((Item arg) => arg.RowId == id).FirstOrDefault();
            Console.WriteLine(oldItem.GetID());
            items.Remove(oldItem);
            Console.WriteLine(items.Count);
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.RowId == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}