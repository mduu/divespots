using System;
using DiveSpots.Drivers.SQL.Core;
using DiveSpots.Drivers.SQL.Entities.Country;
using JetBrains.Annotations;

namespace DiveSpots.Drivers.SQL.Entities.Water
{
    internal class WaterModel : EntityModelBase
    {
        public Guid CountryId { get; set; }
        [UsedImplicitly] public virtual CountryModel? Country { get; set; }
    }
}