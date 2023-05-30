using Roa.Domain.Entities;
using Roa.Domain.Repositories;
using Roa.Infrastructure.Repositories;
using Roa.Infrastructure.Repositories.Dishes;

namespace Roa.API.Modules;

public static class RepositoryModules
{
    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IRepository<Dish>, BaseRepository<Dish>>();
        return service;
    }
}
