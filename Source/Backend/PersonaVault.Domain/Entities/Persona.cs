namespace PersonaVault.Domain.Entities;

public class Persona : EntityBase
{
    public string Name { get; private set; }
    public string Mail { get; private set; }

    public Persona(string name, string mail)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            throw new ArgumentException("O nome é inválido.", nameof(name));

        if (string.IsNullOrWhiteSpace(mail) || !mail.Contains('@'))
            throw new ArgumentException("O formato do e-mail é inválido.", nameof(mail));

        Name = name;
        Mail = mail;
    }
}