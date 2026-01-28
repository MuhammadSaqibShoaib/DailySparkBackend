using System.ComponentModel.DataAnnotations;

namespace AtomsBackend.DTOs.HabitDto
{
    public class UpdateHabitDto
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
