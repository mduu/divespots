using System;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry.Events
{
    public class SpotCreated : DomainEventBase
    {
        public SpotCreated(Guid entityId) : base(entityId)
        {
        }
    }
}