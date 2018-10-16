using SQLite;


namespace DailyTaskManager.Models.DB
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
