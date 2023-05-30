using Microsoft.EntityFrameworkCore;
using Roa.Infrastructure.Context;
using Roa.Infrastructure.Repositories;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Infrastructure.Repositories.Dishes;

public class DishRepository : BaseRepository<Dish>
{
    public DishRepository(ApplicationContext context) : base(context)
    {
    }

    public new async Task<Dish> GetById(int id)
    {
        return await _context.Dishes.SingleOrDefaultAsync(x => x.Id == id);
    }
    public new IQueryable<Dish> GetAll()
    {
        return _context.Dishes.AsQueryable();
    }
}
