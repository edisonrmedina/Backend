using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll;


public sealed class GetAllClientsQueryHandler : IRequestHandler<GetAllClientQuery, ErrorOr<IReadOnlyList<ClientAccountResponse>>>
{
    private readonly IClienteAccountRepository _clienteAccoutRepository;

    public GetAllClientsQueryHandler(IClienteAccountRepository clienteAccoutRepository)
    {
        _clienteAccoutRepository = clienteAccoutRepository ?? throw new ArgumentNullException(nameof(clienteAccoutRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<ClientAccountResponse>>> Handle(GetAllClientQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<ClienteAccount> clientes = await _clienteAccoutRepository.GetAll();

        return clientes.Select(cliente => new ClientAccountResponse(
                cliente.PersonaId.Value,
                cliente.Nombre,
                cliente.Genero,
                cliente.Edad,
                cliente.Identificacion,
                new DireccionResponse(cliente.Direccion.Ciudad, cliente.Direccion.Calle),
                cliente.Telefono,
                cliente.Estado
            )).ToList();
    }
}