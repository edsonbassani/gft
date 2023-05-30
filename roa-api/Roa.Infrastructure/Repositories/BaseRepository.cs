using Microsoft.EntityFrameworkCore;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;
using Roa.Infrastructure.Context;

namespace Roa.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : Entity
{
    protected readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }

    public async Task<T> GetById(int id)
    {
        return await GetAll().SingleOrDefaultAsync(p => p.Id == id);
    }
}