using CFL.Domain;
using CFL.Infrastructure.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFL.Infrastructure;

/// <summary>
/// configuration for ExchangeRate entity
/// </summary>
public class ExchangeRateConfiguration : EntityConfiguration<ExchangeRate>
{
    public override void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.Property(t => t.AssetId)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(t => t.QuoteId)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(t => t.Rate)
            .IsRequired();
        
        builder.Property(t => t.Time)
            .IsRequired();
        
        // add common configurations
        base.Configure(builder);
    }
}
