using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiveSpots.SharedKernel;

namespace DiveSpots.Application.Gateways.Database
{
    public interface IEntityRepository<TEntity>
        where TEntity: class, IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}