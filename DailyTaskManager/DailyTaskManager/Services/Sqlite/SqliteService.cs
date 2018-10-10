using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using DailyTaskManager.Helpers;
using DailyTaskManager.Models;
using DailyTaskManager.Services;
using Xamarin.Forms;
using System;

namespace DailyTaskManager.Models.Sqlite
{
    class SqliteService : ISqliteService
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private SQLiteAsyncConnection _sqlCon;

        public SqliteService()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            _sqlCon = new SQLiteAsyncConnection(databasePath);

            CreateDatabase();
        }
        public async void CreateDatabase()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _sqlCon.CreateTableAsync<Item>().ConfigureAwait(false);
            }
        }
        public async Task<IList<Item>> GetAll()
        {
            var items = new List<Item>();
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                items = await _sqlCon.Table<Item>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public Task<IList<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Item item)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await _sqlCon.Table<Item>()
                        .Where(x => x.RowId == item.RowId)
                        .FirstOrDefaultAsync();

                if (existingTodoItem == null)
                {
                    await _sqlCon.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.RowId = existingTodoItem.RowId;
                    await _sqlCon.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public Task Remove(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
