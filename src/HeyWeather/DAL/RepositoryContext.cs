using System;
using System.IO;
using System.Reflection;
using HeyWeather;
using HeyWeather.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Messaging.API.DAL
{
    public class RepositoryContext : DbContext
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<WeatherPreference> WeatherPreferences { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public class RepositoryContextDesignFactory : IDesignTimeDbContextFactory<RepositoryContext>
        {
            public RepositoryContext CreateDbContext(string[] args)
            {
                string AspEnv = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")) ? "Development" : Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{AspEnv}.json")
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration["Database:ConnectionString"];
                var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>()
                    .UseNpgsql(connectionString,
                                npgsqlOptionsAction: sqlOptions =>
                                {
                                    sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                });
                return new RepositoryContext(optionsBuilder.Options);
            }
        }

    }
}