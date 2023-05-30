using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Numerics;
using System.Reflection;
using Roa.Domain;
using Roa.Domain.Entities;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Roa.Infrastructure.Context;
public class ApplicationContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationContext(
      DbContextOptions<ApplicationContext> options,
      IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    #region DbSets

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishType> DishTypes { get; set; }
    public DbSet<Period> Periods { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        SqlConnection connection = new()
        {
            ConnectionString = _configuration.GetConnectionString("Default")
        };

        optionsBuilder.UseSqlServer(connection, x => x.MigrationsAssembly("Roa.Infrastructure"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private static bool LocalEnvironment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";
    }

    private bool IsLocalDatabase()
    {
        var localDb = _configuration.GetSection("EnvSettings:LocalDatabase").Value;
        return bool.Parse(localDb!);
    }
}
