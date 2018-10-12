using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskManager.Models.DB
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
