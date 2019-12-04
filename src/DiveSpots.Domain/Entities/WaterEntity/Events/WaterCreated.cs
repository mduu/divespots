using System;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.WaterEntity.Events
{
    public class WaterCreated : DomainEventBase
    {
        public WaterCreated(Guid entityId) : base(entityId)
        {
        }
    }
}