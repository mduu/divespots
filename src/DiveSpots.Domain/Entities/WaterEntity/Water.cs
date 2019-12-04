using System;
using System.Collections.Generic;
using DiveSpots.Domain.Entities.WaterEntity.Events;
using DiveSpots.Domain.ValueObjects;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.WaterEntity
{
    public class Water : EntityBase
    {
        public Water(ICollection<Translation> name, ICollection<Translation> description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            
            RaiseDomainEvent(new WaterCreated(Id));
        }
        
        internal Water()
        {
        }

        public ICollection<Translation> Name { get; internal set; } = new List<Translation>();
        public ICollection<Translation> Description { get; internal set; } = new List<Translation>();
    }
}