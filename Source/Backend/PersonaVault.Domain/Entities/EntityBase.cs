namespace PersonaVault.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreateOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; protected set; }

    public void SetUpdated() => UpdatedOn = DateTime.UtcNow;
    public void Deactivate() => Active = false;
    public void Activate() => Active = true;
}
