namespace Domain
{
    public record MovementId(Guid Value)
    {
        public MovementId() : this(Guid.NewGuid()) { }
    }
}
