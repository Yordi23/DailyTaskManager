using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskManager.Models.DB
{
    public class Rules
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BindId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
