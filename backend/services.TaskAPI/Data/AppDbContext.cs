using Microsoft.EntityFrameworkCore;
using TaskModel = services.TaskAPI.Models.Task;

namespace services.TaskAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
