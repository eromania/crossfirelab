namespace CFL.Domain.Base;

/// <summary>
/// Defines common properties for domain entities.
/// </summary>
public abstract class Entity
{
    public int ObjectId { get; set; }
    public DateTime Created { get; set; }
    public int CreatedBy { get; set; }
    public int IsValid { get; set; }
}