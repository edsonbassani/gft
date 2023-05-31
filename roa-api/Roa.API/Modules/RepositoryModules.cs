using Roa.Application.DTOs;
using Roa.Application.Repositories;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;
using Roa.Infrastructure.Repositories;

namespace Roa.API.Modules;

public static class RepositoryModules
{
    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IRepository<Dish>, BaseRepository<Dish>>();
        service.AddScoped<IRepositoryDTO<DishDto>, RepositoryDishDto>();

        service.AddScoped<IRepository<DishType>, BaseRepository<DishType>>();
        service.AddScoped<IRepositoryDTO<DishTypeDto>, RepositoryDishTypeDto>();
        return service;
    }
}
