using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavaAPI.Domain.Entities;

namespace SavaAPI.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    { 
        public DbSet<TasksEntity> Tasks { get; set; }
    }
}
