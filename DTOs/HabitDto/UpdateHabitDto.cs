using System.ComponentModel.DataAnnotations;

namespace AtomsBackend.DTOs.HabitDto
{
    public class UpdateHabitDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
