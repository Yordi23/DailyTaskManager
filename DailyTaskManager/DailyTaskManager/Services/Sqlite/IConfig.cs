using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskManager.Services.Sqlite
{
    public interface IConfig
    {
        string DBDirectory { get; }
        ISQLitePlatform Platform {get;} 
    }
}
