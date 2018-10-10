using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskManager.Models.Sqlite
{
    public interface ISqliteService
    {
        Task<IList<Item>> GetAll();
        Task Insert(Item item);
        Task Remove(Item  item);
    }
}
