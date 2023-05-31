using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Roa.API.Modules;
using Roa.API.OData;
using Roa.Infrastructure.Context;
using Roa.API.Middlewares;
using Roa.Domain.Entities;
using AutoMapper.EquivalencyExpression;
using Roa.API.Mapping;

var builder = WebApplication.CreateBuilder(args);
{

  builder.Services.AddODataEdmModel(
    builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }));
    builder.Services.AddODataQueryFilter();
    builder.Services.AddDbContext<ApplicationContext>();
    builder.Services.AddAutoMapper(config => config.AddCollectionMappers(), typeof(Dish));
    builder.Services.AddAutoMapper(typeof(MapProfile));
    builder.Services.AddRepositories();
    builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
      Title = "Roa API",
      Description = "Roa API",
      Version = "v1"
    });
  });
}

var app = builder.Build();
{
  if (app.Environment.IsEnvironment("Local") || app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roa API");
    });

    app.UseMiddleware<ErrorHandlerMiddleware>();
  }

  app.UseHttpsRedirection();

  if (app.Environment.IsEnvironment("Local"))
  {
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
  }
  
    app.UseAuthorization();
    app.MapControllers().AllowAnonymous();
  
  app.MapGet("/healthCheck", () => "API Running");
}
app.Run();
