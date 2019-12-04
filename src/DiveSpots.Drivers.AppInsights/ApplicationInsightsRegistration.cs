using System;
using System.Runtime.CompilerServices;
using DiveSpots.Application.Gateways.Telemetry;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DiveSpots.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] // For FakeItEasy to use "internal" visibility

namespace DiveSpots.Drivers.AppInsights
{
    public static class ApplicationInsightsRegistration
    {
        public static IServiceCollection RegisterAppInsightsServices(this IServiceCollection services)
        {
            services.AddScoped<ITelemetryService, AppInsightsTelemetryService>();

            return services;
        }
    }
}