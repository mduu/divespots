using System;
using System.Collections.Generic;
using DiveSpots.Application.Core;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Waters
{
    public class GetWaterListApiOutput : List<WaterOutputItem>
    {
        public GetWaterListApiOutput(IEnumerable<WaterOutputItem> waterList)
            : base(waterList)
        {
        }
    }
    
    public class WaterOutputItem
    {
        public WaterOutputItem(
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