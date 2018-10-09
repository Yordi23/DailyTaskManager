using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DailyTaskManager.Models;
namespace DailyTaskManager.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T actv);
        Task<bool> UpdateItemAsync(T actv);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        //Task AddItemAsync(Activities newActv);
    }
}
