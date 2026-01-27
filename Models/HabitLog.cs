namespace AtomsBackend.Models
{
    public class HabitLog
    {
        public int Id { get; set; }

        public int HabitId { get; set; }
        public Habit Habit { get; set; } // navigation

        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
