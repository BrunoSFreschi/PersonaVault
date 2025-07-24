namespace PersonaVault.Domain.Entities;

public class Persona : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
}