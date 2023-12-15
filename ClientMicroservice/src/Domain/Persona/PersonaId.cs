namespace Domain;

public record PersonaId (Guid Value)
{
    public PersonaId() : this(Guid.NewGuid()) { }
}

