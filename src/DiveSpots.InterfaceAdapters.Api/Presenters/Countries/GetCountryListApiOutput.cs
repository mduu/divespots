using System;
using System.Collections.Generic;
using DiveSpots.Application.Core;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Countries
{
    public class GetCountryListApiOutput : List<CountryOutputItem>, IEnumerable<CountryOutputItem>
    {
        public GetCountryListApiOutput(IEnumerable<CountryOutputItem> countryList)
            : base(countryList)
        {
        }
    }
    
    public class CountryOutputItem
    {
        public CountryOutputItem(Guid id, IEnumerable<TranslationData> name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public IEnumerable<TranslationData> Name { get; }
    }
}