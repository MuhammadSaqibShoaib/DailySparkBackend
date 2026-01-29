using AtomsBackend.DTOs.HabitDto;
using AtomsBackend.Models;

namespace AtomsBackend.Services.Interfaces
{
    public interface IHabitService
    {
        Task<HabitDto> CreateHabitAsync(int userId, CreateHabitDto createHabitDto);
        Task<IEnumerable<HabitDto>> GetAllHabits(int userId);
        Task<HabitDto> GetHabitByIdAsync(int habitId, int userId);
        Task<HabitDto> UpdateHabitAsync(int habitId,int userId, UpdateHabitDto dto);
        Task DeleteHabitAsync(int habitId, int userId);
    }
}
