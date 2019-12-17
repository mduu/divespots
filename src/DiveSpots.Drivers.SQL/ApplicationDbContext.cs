using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Drivers.SQL.Entities.Country;
using DiveSpots.Drivers.SQL.Entities.Spot;
using DiveSpots.Drivers.SQL.Entities.Water;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiveSpots.Drivers.SQL
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IMediator mediator;

        public ApplicationDbContext([NotNull] IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            [NotNull] IMediator mediator)
            : base(options)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        [UsedImplicitly] internal virtual ISet<CountryModel>? Countries { get; set; }
        [UsedImplicitly] internal virtual ISet<WaterModel>? Waters { get; set; }
        [UsedImplicitly] internal virtual ISet<SpotModel>? Spots { get; set; }

        public override int SaveChanges()
        {
            throw new InvalidOperationException("Use only the SaveChangesAsync() because synchronous saving is not supported!");
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await DispatchDomainEventsForSuccessfullySavedEntities();
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new WaterConfiguration());
            builder.ApplyConfiguration(new SpotConfiguration());
        }
        
        private async Task DispatchDomainEventsForSuccessfullySavedEntities()
        {
            var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                .Select(e => e.Entity)
                .Where(e => e.UncommittedDomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.UncommittedDomainEvents.ToArray();
                entity.UncommittedDomainEvents.Clear();
                foreach (var domainEvent in events)
                {
                    await mediator.Publish(domainEvent);
                }
            }
        }

    }
}