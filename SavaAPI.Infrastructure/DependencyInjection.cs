using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SavaAPI.Infrastructure.Data;
using SavaAPI.Domain.Interfaces;
using SavaAPI.Infrastructure.Repositories;

namespace SavaAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("SavaDB");
 
            });


            services.AddScoped<ITasksRepository, TasksRepository>();

            return services;
        }  
    }
}
