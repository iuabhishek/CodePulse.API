
using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Infrastructure.Data;
using CodePulse.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=ABHI;Database=CodePulseDb;TrustServerCertificate=True; Trusted_Connection=True;");
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
