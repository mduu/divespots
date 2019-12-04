using System;
using DiveSpots.SharedKernel.Services;
using MediatR;

namespace DiveSpots.SharedKernel
{
    public abstract class DomainEventBase : INotification
    {
        public DomainEventBase(Guid entityId)
        {
            EntityId = entityId;
        }
        
        public DateTime DateOccurred { get; } = SystemClock.Now;
        public Guid EntityId { get; }
    }
}