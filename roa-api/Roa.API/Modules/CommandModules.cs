using Roa.Application.Commands.Dishes.Get;
using Roa.Application.Commands.Dishes.List;
using Roa.Application.Commands.DishTypes.Get;

namespace Roa.API.Modules;

public static class CommandModules
{
    public static IServiceCollection AddCommands(this IServiceCollection service)
    {
        #region Dish
        service.AddTransient<ListDishHandler, ListDishHandler>();
        service.AddTransient<GetDishHandler, GetDishHandler>();
        #endregion

        #region DishTypes
        service.AddTransient<ListDishTypeHandler, ListDishTypeHandler>();
        service.AddTransient<GetDishTypeHandler, GetDishTypeHandler>();
        #endregion
        return service;
    }
}
