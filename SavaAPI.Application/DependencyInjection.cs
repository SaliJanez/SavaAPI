using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SavaAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
