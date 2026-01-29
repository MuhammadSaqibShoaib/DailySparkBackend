using AtomsBackend.DTOs.HabitDto;
using AtomsBackend.Extensions;
using AtomsBackend.Models;
using AtomsBackend.Services;
using AtomsBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AtomsBackend.Controllers
{
    [Authorize]
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
            int userId = User.GetUserId();
            HabitDto habitDto = await _habitService.CreateHabitAsync(userId, dto);
            return Ok(habitDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHabits()
        {
            int userId = User.GetUserId();
            IEnumerable<HabitDto> habitDtos = await _habitService.GetAllHabits(userId);
            return Ok(habitDtos);
        }
        [HttpGet("{habitId}")]
        public async Task<IActionResult> GetHabitById(int habitId)
        {
            int userId = User.GetUserId();
            HabitDto habitDto = await _habitService.GetHabitByIdAsync(habitId, userId);

            if (habitDto == null)
                return NotFound();
            return Ok(habitDto);
        }


        [HttpPut("{habitId}")]
        public async Task<IActionResult> UpdateHabit(int habitId, [FromBody] UpdateHabitDto dto)
        {
            int userId = User.GetUserId();
            var habitDto = await _habitService.UpdateHabitAsync(habitId, userId,dto);
            return Ok(habitDto);
        }

        [HttpDelete("{habitId}")]
        public async Task<IActionResult> DeleteHabit(int habitId)
        {
            int userId = User.GetUserId();
            await _habitService.DeleteHabitAsync(habitId, userId);

            return NoContent(); // 204 → standard for successful delete
        }


    }
}
