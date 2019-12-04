using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace DiveSpots.SharedKernel
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        [JsonIgnore]
        public IList<DomainEventBase> UncommittedDomainEvents { get; } = new List<DomainEventBase>();

        protected void RaiseDomainEvent([NotNull] DomainEventBase domainEvent)
        {
            if (domainEvent == null) throw new ArgumentNullException(nameof(domainEvent));
            
            UncommittedDomainEvents.Add(domainEvent);
        }
    }
}