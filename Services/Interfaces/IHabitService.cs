using AtomsBackend.DTOs.HabitDto;
using AtomsBackend.Models;

namespace AtomsBackend.Services.Interfaces
{
    public interface IHabitService
    {
        Task<HabitDto> CreateHabitAsync(int userId, CreateHabitDto createHabitDto);
        Task<IEnumerable<HabitDto>> GetAllHabits();
        Task<IEnumerable<HabitDto>> GetHabitsByUserAsync(int userId);
        Task<HabitDto> GetHabitByIdAsync(int habitId);
        Task<HabitDto> UpdateHabitAsync(int habitId, UpdateHabitDto dto);
        Task<bool> DeleteHabitAsync(int habitId);
    }
}
