using System;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry.Events
{
    public class SpotUpdated : DomainEventBase
    {
        public SpotUpdated(Guid entityId) : base(entityId)
        {
        }
    }
}