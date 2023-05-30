using Roa.Domain.Entities;

namespace Roa.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetById(int id);
}