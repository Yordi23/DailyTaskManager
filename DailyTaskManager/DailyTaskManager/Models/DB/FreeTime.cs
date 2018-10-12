using SQLite;

namespace DailyTaskManager.Models.DB
{
    public class FreeTime
    {
        public string Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

    }
}
