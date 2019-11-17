using System;
using DiveSpots.Application;
using DiveSpots.Drivers.SQL;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiveSpots.Web
{
    [UsedImplicitly]
    public static class ApplicationServices
    {
        public static void Register(
            [NotNull] IServiceCollection services,
            [NotNull] IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services
                .AddDiveSpotsSqlDriver()
                .AddDiveSpotsSharedKernel()
                .RegisterServices();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}