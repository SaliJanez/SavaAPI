using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SavaAPI.Infrastructure.Data;

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
            return services;
        }
    }
}
