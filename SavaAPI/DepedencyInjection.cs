using SavaAPI.Application;
using SavaAPI.Infrastructure;

namespace SavaAPI
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddAplicationDI();
            services.AddAInfrastructureDI();
            return services;
        }
    }
}
