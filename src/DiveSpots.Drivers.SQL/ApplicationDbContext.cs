﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Domain.Entities;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiveSpots.Drivers.SQL
{
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
            
            //builder.ApplyConfiguration(new CommentDataConfiguration());
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