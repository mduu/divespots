using System.Collections.Generic;
using DiveSpots.Drivers.SQL.Core;
using DiveSpots.Drivers.SQL.Entities.Water;

namespace DiveSpots.Drivers.SQL.Entities.Country
{
    internal class CountryModel : EntityModelBase
    {
        public virtual ICollection<WaterModel> Waters { get; set; }
    }
}