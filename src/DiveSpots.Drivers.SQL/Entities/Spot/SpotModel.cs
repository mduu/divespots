using System;
using DiveSpots.Drivers.SQL.Core;
using DiveSpots.Drivers.SQL.Entities.Water;

namespace DiveSpots.Drivers.SQL.Entities.Spot
{
    internal class SpotModel : EntityModelBase
    {
        public Guid WaterId { get; set; }
        public virtual WaterModel Water { get; set; }
    }
}