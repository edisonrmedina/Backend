namespace Domain;

public record ClienteAccountId(Guid Value)
{
    public ClienteAccountId() : this(Guid.NewGuid()) { }
}

