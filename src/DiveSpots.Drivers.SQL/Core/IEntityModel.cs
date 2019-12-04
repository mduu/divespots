using System;

namespace DiveSpots.Drivers.SQL.Core
{
    internal interface IEntityModel
    {
        Guid Id { get; set; }
        string JsonData { get; set; }
    }
}