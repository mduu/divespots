using System;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.CountryEntity.Events
{
    public class CountryCreated : DomainEventBase
    {
        public CountryCreated(Guid id)
            : base(id)
        {
        }
    }
}