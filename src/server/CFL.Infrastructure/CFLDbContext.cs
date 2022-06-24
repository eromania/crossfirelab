using System.Reflection;
using CFL.Application.Interfaces;
using CFL.Domain;
using CFL.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace CFL.Infrastructure;

/// <summary>
/// ef core in memory db context
/// </summary>
public class CFLDbContext : DbContext, IApplicationDbContext
{
    public DbSet<ExchangeRate> ExchangeRates { get; set; } = null!;
   
    public CFLDbContext(DbContextOptions options) : base(options)
    {
    }

    //override save method for default values of entities
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.Now;
                    entry.Entity.CreatedBy = 111;
                    entry.Entity.IsValid = 1;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    //load all entity configurations, code block from my last project
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var configurations = assembly.DefinedTypes.Where(t =>
                t.ImplementedInterfaces.Any(i =>
                    i.IsGenericType && i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
                        StringComparison.InvariantCultureIgnoreCase)) && t.IsClass && !t.IsAbstract && !t.IsNested)
            .ToList();

        foreach (var configuration in configurations)
        {
            var entityType = configuration.GetInterfaces().Single().GenericTypeArguments.Single();

            var applyConfigMethods = typeof(ModelBuilder).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name.Equals("ApplyConfiguration") && m.IsGenericMethod);

            var applyConfigMethod = applyConfigMethods.Single(m =>
                m.GetParameters().Any(p => p.ParameterType.Name.Equals(typeof(IEntityTypeConfiguration<>).Name)));

            var method = applyConfigMethod.MakeGenericMethod(entityType);
            method.Invoke(modelBuilder, new[]
            {
                Activator.CreateInstance(configuration)
            });
        }
    }

}