using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Application.Core;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.Application.Gateways.Telemetry;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DiveSpots.Application.UseCases.Country.GetList
{
    [UsedImplicitly]
    public class GetCountryListInteractor : IRequestHandler<GetCountryList, UseCaseResult>
    {
        private readonly ILogger logger;
        private readonly ICountryRepository countryRepository;
        private readonly ITelemetryService telemetryService;

        public GetCountryListInteractor(
            ILogger<GetCountryListInteractor> logger,
            ICountryRepository countryRepository,
            ITelemetryService telemetryService)
        {
            this.logger = logger;
            this.countryRepository = countryRepository;
            this.telemetryService = telemetryService;
        }

        public async Task<UseCaseResult> Handle(GetCountryList request, CancellationToken cancellationToken)
        {
            using var logScope = logger.BeginScope("Begin {name}", nameof(GetCountryListInteractor));

            var countries = await countryRepository.GetAllAsync();
            
            request.OutputPort?.Output(
                new GetCountryListInteractorOutput(
                    countries.Select(c =>
                        new GetCountryListInteractorOutput.CountryListItem(
                            c.Id, c.Name.MapTo()))));

            telemetryService.TrackEvent(TelemetryEventNames.GetCountries);
            
            return UseCaseResult.Success();
        }
    }
}