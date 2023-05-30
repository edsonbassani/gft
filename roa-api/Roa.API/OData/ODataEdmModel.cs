using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Roa.Domain.Entities;
using DishEntity = Roa.Domain.Entities.Dish;
using DishTypeEntity = Roa.Domain.Entities.DishType;
using PeriodEntity = Roa.Domain.Entities.Period;

namespace Roa.API.OData;

public static class ODataEdmModel
{
  public static IServiceCollection AddODataEdmModel(this IServiceCollection services, IMvcBuilder builder)
  {
    builder.AddOData(option =>
    {
      option.EnableQueryFeatures(1000);
      option.AddRouteComponents("odata", GetEdmModel());
    });

    return services;
  }

  private static IEdmModel GetEdmModel()
  {
    var builder = new ODataConventionModelBuilder();

    builder.EntityType<DishEntity>().HasKey(d => d.Id);
    builder.EntityType<DishTypeEntity>().HasKey(d => d.Id);
    builder.EntityType<PeriodEntity>().HasKey(d => d.Id);

    return builder.GetEdmModel();
  }
}
