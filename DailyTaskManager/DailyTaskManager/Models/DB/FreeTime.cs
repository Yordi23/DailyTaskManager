using SQLite;

namespace DailyTaskManager.Models.DB
{
    public class FreeTime
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Day { get; set; }
        public double StartTime { get; set; }
        public double EndTime { get; set; }
    }
}
