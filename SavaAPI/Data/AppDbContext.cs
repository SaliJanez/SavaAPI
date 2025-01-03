using Microsoft.EntityFrameworkCore;

namespace SavaAPI.Data
{ 
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Tasks> Tasks { get; set; }

    }
}
