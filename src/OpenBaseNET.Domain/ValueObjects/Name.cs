namespace OpenBaseNET.Domain.ValueObjects;

public sealed class Name
{
    public string Value { get; }

    private Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Nome não pode ser branco ou nulo", nameof(value));
        
        if(value.Length > 255)
            throw new ArgumentException("Nome não pode ter mais que 255 caracteres", nameof(value));
        
        Value = value;
    }
    
    public static implicit operator string(Name name) => name.ToString();
    public static implicit operator Name(string value) => new(value);
    public override string ToString() => Value;
}