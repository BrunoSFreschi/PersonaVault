using PersonaVault.Domain.ValueObjects;

namespace PersonaVault.Domain.Entities;

public class Persona : EntityBase
{
    public Name Name { get; private set; }
    public Email Mail { get; private set; }

    public Persona(Name _name, Email _mail)
    {
        Name = _name;
        Mail = _mail;
    }

    public void Update(Name _name, Email _mail)
    {
        Name = _name;
        Mail = _mail;
        SetUpdated();
    }
}