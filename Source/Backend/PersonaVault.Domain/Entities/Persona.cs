namespace PersonaVault.Domain.Entities;

public class Persona : EntityBase
{
    public string Name { get; private set; }
    public string Mail { get; private set; }

    public Persona(string _name, string _mail)
    {
        Validate(_name, _mail);

        Name = _name;
        Mail = _mail;
    }

    public void Update(string _name, string _mail)
    {
        Validate(_name, _mail);

        Name = _name;
        Mail = _mail;
        SetUpdated();
    }

    private void Validate(string name, string mail)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            throw new ArgumentException("O nome é inválido.", nameof(name));

        if (string.IsNullOrWhiteSpace(mail) || !mail.Contains('@'))
            throw new ArgumentException("O formato do e-mail é inválido.", nameof(mail));
    }
}