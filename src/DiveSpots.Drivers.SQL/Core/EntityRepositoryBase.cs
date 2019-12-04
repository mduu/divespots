using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DiveSpots.Drivers.SQL.Core
{
    internal abstract class EntityRepositoryBase<TEntity, TEntityModel> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
        where TEntityModel : class, IEntityModel, new()
    {
        private readonly ApplicationDbContext context;

        protected EntityRepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var dbEntity = await GetDbSet()
                .FirstOrDefaultAsync(e => e.Id == id);

            return dbEntity != null
                ? GetEntityFromJsonData(dbEntity)
                : null;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var dbEntities = await GetDbSet().ToListAsync();

            return dbEntities.Select(GetEntityFromJsonData);
        }

        public async Task InsertAsync(TEntity entity)
        {
            var model = CreateEntityModel(entity);
            MapToModel(entity, model);
            GetDbSet().Add(model);
            
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var model = await GetDbSet().FirstOrDefaultAsync();
            if (model == null)
            {
                throw new DataNotFoundException(entity.GetType(), entity.Id);
            }
            
            MapToModel(entity, model);
            
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var model = await GetDbSet().FirstOrDefaultAsync();
            if (model == null)
            {
                throw new DataNotFoundException(entity.GetType(), entity.Id);
            }

            GetDbSet().Remove(model);
            await context.SaveChangesAsync();
        }

        protected DbSet<TEntityModel> GetDbSet()
            => context.Set<TEntityModel>();

        protected virtual void MapToModel(TEntity entity, TEntityModel model)
        {
            model.Id = entity.Id;
            SetJsonDataFromEntity(model, entity);
        }

        protected virtual TEntityModel CreateEntityModel(TEntity entity)
            => new TEntityModel();

        protected TEntity GetEntityFromJsonData(TEntityModel model)
            => JsonConvert.DeserializeObject<TEntity>(model.JsonData) ?? throw new InvalidOperationException("JsonData field is null!");

        protected void SetJsonDataFromEntity(TEntityModel model, TEntity entity)
            => model.JsonData = JsonConvert.SerializeObject(entity);
    }
}