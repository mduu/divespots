using System;
using System.Collections.Generic;
using DiveSpots.Application.Core;

namespace DiveSpots.Application.UseCases.Country.GetList
{
    public class GetCountryListInteractorOutput
    {
        public GetCountryListInteractorOutput(IEnumerable<CountryListItem> countries)
        {
            Countries = countries;
        }

        public IEnumerable<CountryListItem> Countries { get; }

        public class CountryListItem
        {
            public CountryListItem(Guid id, IEnumerable<TranslationData> name)
            {
                Id = id;
                Name = name;
            }

            public Guid Id { get; }
            public IEnumerable<TranslationData> Name { get; }
        }
    }
}