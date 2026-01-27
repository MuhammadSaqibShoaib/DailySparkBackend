using AtomsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AtomsBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Habit> Habits { get; set; } = null;
        public DbSet<HabitLog> HabitLogs { get; set; } = null;
    }
}
