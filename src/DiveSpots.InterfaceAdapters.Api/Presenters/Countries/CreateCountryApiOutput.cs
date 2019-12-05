using System;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Countries
{
    public class CreateCountryApiOutput
    {
        public CreateCountryApiOutput(Guid countryId)
        {
            CountryId = countryId;
        }

        public Guid CountryId { get; }
    }
}