using CFL.Domain;
using Microsoft.EntityFrameworkCore;

namespace CFL.Application.Interfaces;

/// <summary>
/// Interface for ApplicationDbContext
/// </summary>
public interface IApplicationDbContext
{
    DbSet<ExchangeRate> ExchangeRates { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}