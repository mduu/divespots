using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DiveSpots.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection RegisterApplicationServices([NotNull] this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

    }
}