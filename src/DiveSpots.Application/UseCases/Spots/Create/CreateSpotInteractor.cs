using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.Domain.Entities.SpotEntry;
using DiveSpots.SharedKernel;
using FluentValidation.Results;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DiveSpots.Application.UseCases.Spots.Create
{
    [UsedImplicitly]
    internal class CreateSpotInteractor : IRequestHandler<CreateSpot, UseCaseResult>
    {
        private readonly ILogger logger;
        private readonly ISpotRepository spotRepository;
        private readonly IWaterRepository waterRepository;

        public CreateSpotInteractor(
            ILogger logger,
            ISpotRepository spotRepository,
            IWaterRepository waterRepository)
        {
            this.logger = logger;
            this.spotRepository = spotRepository;
            this.waterRepository = waterRepository;
        }

        public async Task<UseCaseResult> Handle(CreateSpot request, CancellationToken cancellationToken)
        {
            using var logScope = logger.BeginScope("Begin {name}", nameof(CreateSpotInteractor), request);

            var water = await waterRepository.GetByIdAsync(request.WaterId);
            if (water == null)
            {
                logger.LogError("Water with ID [{waterId}] not found!", request.WaterId);
                return UseCaseResult.NotFound(new []{ new ValidationFailure("waterId", "Water not found!"), });
            }
            
            var spot = new Spot(
                request.WaterId,
                request.Name,
                request.AlternativeName,
                request.Description,
                request.City,
                request.Difficulty,
                request.Coordinates);

            await spotRepository.InsertAsync(spot);
            
            request.OutputPort.Output(new CreateSpotInteractorOutput(spot.Id));
            
            return UseCaseResult.Success();
        }
    }
}