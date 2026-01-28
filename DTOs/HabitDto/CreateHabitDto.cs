using System.ComponentModel.DataAnnotations;

namespace AtomsBackend.DTOs.HabitDto
{
    public class CreateHabitDto
    {
        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
