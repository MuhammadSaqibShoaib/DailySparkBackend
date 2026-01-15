namespace AtomsBackend.Models
{
    public class HabitLog
    {
        public int id { get; set; }
        public int habitId { get; set; }
        public DateTime date { get; set; }
        public bool isCompleted { get; set; }
    }
}
