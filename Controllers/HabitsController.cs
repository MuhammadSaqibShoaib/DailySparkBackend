using AtomsBackend.DTOs.HabitDto;
using AtomsBackend.Models;
using AtomsBackend.Services;
using AtomsBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AtomsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService _habitService;

        public HabitsController(IHabitService habitService)
        {
            this._habitService = habitService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHabit([FromBody] CreateHabitDto dto)
        {
            int userId = 1;
            HabitDto habitDto = await _habitService.CreateHabitAsync(userId, dto);
            return Ok(habitDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHabits()
        {
            IEnumerable<HabitDto> habitDtos = await _habitService.GetAllHabits();
            return Ok(habitDtos);
        }
        [HttpGet("{habitId}")]
        public async Task<IActionResult> GetHabitById(int habitId)
        {
            HabitDto habitDto = await _habitService.GetHabitByIdAsync(habitId);

            if (habitDto == null)
                return NotFound();
            return Ok(habitDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetHabitsByUserId(int userId)
        {
            IEnumerable<HabitDto> habitDtos = await _habitService.GetHabitsByUserAsync(userId);
            return Ok(habitDtos);
        }

        [HttpPut("{habitId}")]
        public async Task<IActionResult> UpdateHabit(int habitId, [FromBody] UpdateHabitDto dto)
        {

            var habitDto = await _habitService.UpdateHabitAsync(habitId, dto);
            return Ok(habitDto);
        }

        [HttpDelete("{habitId}")]
        public async Task<IActionResult> DeleteHabit(int habitId)
        {
            await _habitService.DeleteHabitAsync(habitId);

            return NoContent(); // 204 → standard for successful delete
        }


    }
}
