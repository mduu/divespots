using System;

namespace DiveSpots.Application.UseCases.Country.Create
{
    public class CreateCountryInteractorOutput
    {
        public CreateCountryInteractorOutput(Guid countryId)
        {
            CountryId = countryId;
        }

        public Guid CountryId { get; }
    }
}