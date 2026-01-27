using AtomsBackend.DTOs.HabitDto;

namespace AtomsBackend.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }   // navigation

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<HabitLog>? HabitLogs { get; set; }
    }
}
