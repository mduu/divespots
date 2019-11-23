using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace DiveSpots.Drivers.SQL
{
    public static class SqlRegistrations
    {
        public static IServiceCollection AddDiveSpotsSqlDriver([NotNull] this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            services.AddScoped<ApplicationDbContext>();

            return services;
        }
    }
}