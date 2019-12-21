using System;
using System.Collections.Generic;
using DiveSpots.Application.Core;

namespace DiveSpots.Application.UseCases.Waters.GetList
{
    public class GetWaterListInteractorOutput
    {
        public GetWaterListInteractorOutput(IEnumerable<WaterListItem> waters)
        {
            Waters = waters;
        }

        public IEnumerable<WaterListItem> Waters { get; }

        public class WaterListItem
        {
            public WaterListItem(
                Guid id,
                IEnumerable<TranslationData> name, 
                IEnumerable<TranslationData> description)
            {
                Id = id;
                Name = name;
                Description = description;
            }

            public Guid Id { get; }
            public IEnumerable<TranslationData> Name { get; }
            public IEnumerable<TranslationData> Description { get; }
        }
    }
}