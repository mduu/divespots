using System;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DiveSpots.Application
{
    public static class ApplicationRegistration
    {
        public static void RegisterServices([NotNull] IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

    }
}