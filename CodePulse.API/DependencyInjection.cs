using CodePulse.Infrastructure;
using CodePulse.Application;

namespace CodePulse.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI();
            return services;
        }
    }
}
