using System;
using System.Collections.Generic;
using DiveSpots.Domain.Entities.CountryEntity;
using DiveSpots.Domain.Entities.WaterEntity.Events;
using DiveSpots.Domain.ValueObjects;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.WaterEntity
{
    public class Water : EntityBase
    {
        public Water(Guid countryId, ICollection<Translation> name, ICollection<Translation> description)
        {
            Id = Guid.NewGuid();
            CountryId = countryId;
            Name = name;
            Description = description;
            
            RaiseDomainEvent(new WaterCreated(Id));
        }
        
        internal Water()
        {
        }
        
        public Guid CountryId { get; internal set; }
        public ICollection<Translation> Name { get; internal set; } = new List<Translation>();
        public ICollection<Translation> Description { get; internal set; } = new List<Translation>();
    }
}