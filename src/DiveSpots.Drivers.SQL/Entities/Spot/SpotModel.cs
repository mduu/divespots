using System;
using DiveSpots.Drivers.SQL.Core;
using DiveSpots.Drivers.SQL.Entities.Water;
using JetBrains.Annotations;

namespace DiveSpots.Drivers.SQL.Entities.Spot
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    internal class SpotModel : EntityModelBase
    {
        public Guid WaterId { get; set; }
        [UsedImplicitly] public virtual WaterModel? Water { get; set; }
    }
}