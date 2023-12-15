namespace Domain
{
    public interface IClienteAccountRepository
    {
        Task<List<ClienteAccount>> GetAll();
        Task<ClienteAccount?> GetByIdAsync(PersonaId id);
        Task<bool> ExistsAsync(PersonaId id);
        void Add(ClienteAccount ClienteAccount);
        void Update(ClienteAccount ClienteAccount);
        void Delete(ClienteAccount ClienteAccount);
    }
}
