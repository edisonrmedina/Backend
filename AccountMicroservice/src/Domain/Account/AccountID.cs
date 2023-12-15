namespace Domain;

public record AccountID(Guid Value)
{
    public AccountID() : this(Guid.NewGuid()) { }
}

