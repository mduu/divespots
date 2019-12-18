using System;
using System.Collections.Generic;
using DiveSpots.Application.Core;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Countries
{
    public class GetCountryListApiOutput
    {
        public GetCountryListApiOutput(IEnumerable<CountryItem> countries)
        {
            Countries = countries;
        }

        public IEnumerable<CountryItem> Countries { get; }

        public class CountryItem
        {
            public CountryItem(Guid id, IEnumerable<TranslationData> name)
            {
                Id = id;
                Name = name;
            }

            public Guid Id { get; }
            public IEnumerable<TranslationData> Name { get; }
        }
    }
}