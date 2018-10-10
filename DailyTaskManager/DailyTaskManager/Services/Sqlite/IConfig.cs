using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskManager.Services.Sqlite
{
    public interface IConfig
    {
        SQLiteConnection Connection { get; }
    }
}
