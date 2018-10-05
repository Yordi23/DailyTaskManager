using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyTaskManager.Models;

namespace DailyTaskManager.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item("Estudiar mat", "Realizar los estudios de las unidades 5, 6, 7 de algebra",
                "INTEC", DateTime.Parse("10/3/18"), 5),
                new Item("Estudiar prob", "Realizar los estudios de las unidades boa",
                    "INTEC", DateTime.Parse("10/3/18"), 2),
                new Item("Estudiar fisica", "Realizar los estudios de las unidades lee",
                    "INTEC", DateTime.Parse("10/3/18"), 0),
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
            var oldItem = items.Where((Item arg) => arg.RowId == id).FirstOrDefault();
            items.Remove(oldItem);

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