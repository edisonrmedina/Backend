namespace Domain;


    public interface IMovementRepository
    {
        Task<List<Movement>> GetAll();
        Task<Movement?> GetByIdAsync(MovementId id);
        Task<bool> ExistsAsync(MovementId id);
        void Add(Movement ClienteAccount);
        void Update(Movement ClienteAccount);
        void Delete(Movement ClienteAccount);
        Task<List<Movement>> GetMovimientosByDateRangeAndAccountsAsync(DateTime fechaInicio, DateTime fechaFin, List<AccountID> cuentaIds);
}

