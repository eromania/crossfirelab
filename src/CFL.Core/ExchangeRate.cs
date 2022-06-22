using CFL.Domain.Base;

namespace CFL.Domain;

public class ExchangeRate : Entity
{
    public string AssetId { get; set; } = null!;
    public string QuoteId { get; set; } = null!;
    public DateTime Time { get; set; }
    public decimal Rate { get; set; }
}