using System;
using System.Collections.Generic;
using DiveSpots.Domain.Entities.CountryEntity.Events;
using DiveSpots.Domain.ValueObjects;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.CountryEntity
{
    public class Country : EntityBase
    {
        public Country(ICollection<Translation> name)
        {
            Id = Guid.NewGuid();
            Name = name;
            
            RaiseDomainEvent(new CountryCreated(Id));
        }
        
        internal Country()
        {
        }
        
        public ICollection<Translation> Name { get; internal set; } = new List<Translation>();
    }
}