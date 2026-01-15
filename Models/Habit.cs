namespace AtomsBackend.Models
{
    public class Habit
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public bool isActive { get; set; }
        public DateTime createdAt { get; set; }
    }
}
