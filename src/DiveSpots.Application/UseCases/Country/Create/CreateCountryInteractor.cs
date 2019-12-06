using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Application.Core;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DiveSpots.Application.UseCases.Country.Create
{
    public class CreateCountryInteractor : IRequestHandler<CreateCountry, UseCaseResult>
    {
        private readonly ILogger logger;
        private readonly ICountryRepository countryRepository;

        public CreateCountryInteractor(
            ILogger<CreateCountryInteractor> logger,
            ICountryRepository countryRepository)
        {
            this.logger = logger;
            this.countryRepository = countryRepository;
        }

        public async Task<UseCaseResult> Handle(CreateCountry request, CancellationToken cancellationToken)
        {
            using var logScope = logger.BeginScope("Begin Handle", request);

            var country = new Domain.Entities.CountryEntity.Country(request.Name.MapTo());
            await countryRepository.InsertAsync(country); 
            
            request.OutputPort.Output(new CreateCountryInteractorOutput(country.Id));
            
            return UseCaseResult.Success();
        }
    }
}