using AtomsBackend.Data;
using AtomsBackend.DTOs.HabitDto;
using AtomsBackend.Models;
using AtomsBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AtomsBackend.Services
{
    public class HabitService : IHabitService
    {
        #region Properties
        private AppDbContext _dbContext;

        #endregion

        public HabitService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #region Public Functions
        public async Task<HabitDto> CreateHabitAsync(int userId, CreateHabitDto dto)
        {
            // Map DTO → Entity
            var habit = new Habit
            {
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            // Add to EF Core
            _dbContext.Habits.Add(habit);
            await _dbContext.SaveChangesAsync();

            // Map Entity → DTO for response
            return ConvertToHabitDto(habit);
        }

        public async Task DeleteHabitAsync(int habitId)
        {
            var habit = await _dbContext.Habits.FindAsync(habitId);
            if (habit == null)
                throw new KeyNotFoundException($"Habit with id {habitId} not found");

            _dbContext.Habits.Remove(habit);
            await _dbContext.SaveChangesAsync();
            return;
        }


        public async Task<IEnumerable<HabitDto>> GetAllHabits()
        {
            List<Habit> habits = await _dbContext.Habits.ToListAsync();
            return habits.Select(h => ConvertToHabitDto(h)).ToList();
        }


        public async Task<HabitDto> GetHabitByIdAsync(int habitId)
        {
            Habit habit = await _dbContext.Habits.FindAsync(habitId);
            if (habit != null)
                return ConvertToHabitDto(habit);
            return null;
        }

        public async Task<IEnumerable<HabitDto>> GetHabitsByUserAsync(int userId)
        {
            List<Habit> habits = await _dbContext.Habits.Where(h => h.UserId == userId).ToListAsync();
            return habits.Select(h => ConvertToHabitDto(h)).ToList();

        }

        public async Task<HabitDto> UpdateHabitAsync(int habitId,UpdateHabitDto dto)
        {
            Habit habit = await GetHabit(habitId); 

            if (!string.IsNullOrEmpty(dto.Title))
                habit.Title = dto.Title;

            if (!string.IsNullOrEmpty(dto.Description))
                habit.Description = dto.Description;

            habit.IsActive = dto.IsActive;

            await _dbContext.SaveChangesAsync();

            return ConvertToHabitDto(habit);
        }

        #endregion

        #region Private Functions
        private HabitDto ConvertToHabitDto(Habit habit)
        {
            return new HabitDto
            {
                Id = habit.Id,
                Title = habit.Title,
                Description = habit.Description,
                IsActive = habit.IsActive,
                CreatedAt = habit.CreatedAt
            };
        }

        private async Task<Habit> GetHabit(int habitId)
        {
            return await _dbContext.Habits.FindAsync(habitId)
                        ?? throw new KeyNotFoundException($"Habit with id {habitId} not found");
        }
        #endregion
    }
}
