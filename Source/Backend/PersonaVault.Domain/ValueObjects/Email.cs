using System.Text.RegularExpressions;

namespace PersonaVault.Domain.ValueObjects;

public record Email
{
    public string Address { get; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValid(address))
            throw new ArgumentException("O formato do e-mail é inválido.", nameof(address));
        
        Address = address;
    }

    private static bool IsValid(string email)
        => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public static implicit operator string(Email email)
        => email.Address;
}
