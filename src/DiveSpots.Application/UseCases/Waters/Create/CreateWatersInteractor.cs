using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Application.Core;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.Application.Gateways.Telemetry;
using DiveSpots.Domain.Entities;
using DiveSpots.Domain.Entities.WaterEntity;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DiveSpots.Application.UseCases.Waters.Create
{
    [UsedImplicitly]
    public class CreateWatersInteractor : IRequestHandler<CreateWaters, UseCaseResult>
    {
        private readonly ILogger logger;
        private readonly IWaterRepository waterRepository;
        
        public CreateWatersInteractor(
            ILogger<CreateWatersInteractor> logger,
            IWaterRepository waterRepository,
            ITelemetryService telemetryService)
        {
            this.logger = logger;
            this.waterRepository = waterRepository;
        }
        
        public async Task<UseCaseResult> Handle(CreateWaters request, CancellationToken cancellationToken)
        {
            using var logScope = logger.BeginScope($"Handle {nameof(CreateWaters)}", request);

            var newWaters = new Water(
                request.Name.MapTo(),
                request.Description.MapTo());

            await waterRepository.InsertAsync(newWaters);
            
            return UseCaseResult.Success();
        }
    }
}