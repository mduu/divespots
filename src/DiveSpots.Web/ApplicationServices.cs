using System;
using System.Runtime.CompilerServices;
using DiveSpots.Application;
using DiveSpots.Drivers.SQL;
using DiveSpots.SharedKernel;
using DiveSpots.Web.Core.TokenHandling;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DiveSpots.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] // For FakeItEasy to use "internal" visibilityusing System;

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
            services.AddSingleton(new TokenConfiguration(GetTokenSecurityKey(configuration)));
            services.AddTransient<ITokenGenerator, TokenGenerator>();
        }
        
        private static string GetTokenSecurityKey(IConfiguration configuration)
        {
            var tokenSecurityKey = configuration[nameof(TokenConfiguration.TokenSecurityKey)];

            return string.IsNullOrWhiteSpace(tokenSecurityKey)
                ? throw new InvalidOperationException("Not 'TokenSecurityKey' configured!")
                : tokenSecurityKey;
        }
    }
}