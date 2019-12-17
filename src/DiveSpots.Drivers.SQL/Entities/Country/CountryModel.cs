using System.Collections.Generic;
using DiveSpots.Drivers.SQL.Core;
using DiveSpots.Drivers.SQL.Entities.Water;
using JetBrains.Annotations;

namespace DiveSpots.Drivers.SQL.Entities.Country
{
    internal class CountryModel : EntityModelBase
    {
        [UsedImplicitly] public virtual ICollection<WaterModel> Waters { get; set; }
    }
}