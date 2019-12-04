using System;

namespace DiveSpots.Drivers.SQL.Core
{
    internal class EntityModelBase : IEntityModel
    {
        public Guid Id { get; set; }
        public string JsonData { get; set; } = "";
    }
}