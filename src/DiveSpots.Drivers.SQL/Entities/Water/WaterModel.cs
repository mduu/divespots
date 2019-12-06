using System;
using DiveSpots.Drivers.SQL.Core;
using DiveSpots.Drivers.SQL.Entities.Country;

namespace DiveSpots.Drivers.SQL.Entities.Water
{
    internal class WaterModel : EntityModelBase
    {
        public Guid CountryId { get; set; }
        public virtual CountryModel Country { get; set; }
    }
}