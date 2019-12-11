using System;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry.Events
{
    public class SpotDeleted : DomainEventBase
    {
        public SpotDeleted(Guid entityId) : base(entityId)
        {
        }
    }
}