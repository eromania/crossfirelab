namespace CFL.Domain.Base;

/// <summary>
/// Defines common properties for domain entities.
/// </summary>
public abstract class Entity
{
    public int ObjectId { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public int CreatedBy { get; set; } = 111;
    public int IsValid { get; set; } = 1;
}