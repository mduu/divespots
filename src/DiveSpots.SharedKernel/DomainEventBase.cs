using System;
using DiveSpots.SharedKernel.Services;
using MediatR;

namespace DiveSpots.SharedKernel
{
    public abstract class DomainEventBase : INotification
    {
        public DateTime DateOccurred { get; } = SystemClock.Now;
    }
}