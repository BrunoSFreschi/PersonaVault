namespace PersonaVault.Domain.ValueObjects;

public record Name
{
    public string Text { get; }

    public Name(string text)
    {
        if (string.IsNullOrWhiteSpace(text) || text.Length < 3)
            throw new ArgumentException("O nome é inválido.", nameof(text));

        Text = text;
    }

    public static implicit operator string(Name name)
        => name.Text;
}
