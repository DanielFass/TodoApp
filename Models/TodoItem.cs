using SQLite;

namespace TodoApp.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool Done { get; set; }
    }
}