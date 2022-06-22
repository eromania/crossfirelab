using CFL.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFL.Infrastructure.Base;

/// <summary>
/// Provides EF configuration information for base entity.
/// </summary>
/// <typeparam name="T">Entity Type</typeparam>
public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // builder.ToTable(typeof(T).Name);
        builder.HasKey(c => c.ObjectId);
        builder.Property(c => c.ObjectId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.IsValid)
            .IsRequired();

        builder.Property(c => c.Created)
            .IsRequired();

        builder.Property(c => c.CreatedBy)
            .IsRequired();
    }
}