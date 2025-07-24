namespace PersonaVault.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public bool Active { get; protected set; } = true;
    public DateTime CreateOn { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; protected set; }

    public void SetUpdated() => UpdatedOn = DateTime.UtcNow;
    public void Deactivate() => Active = false;
    public void Activate() => Active = true;
}
