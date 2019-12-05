using System;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.Drivers.SQL.Entities.Country;
using DiveSpots.Drivers.SQL.Entities.Water;
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
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IWaterRepository, WaterRepository>();

            return services;
        }
    }
}