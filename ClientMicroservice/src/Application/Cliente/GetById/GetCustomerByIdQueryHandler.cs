
using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;


public sealed class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ErrorOr<ClientAccountResponse>>
{
    private readonly IClienteAccountRepository _clienteRepository;

    public GetClientByIdQueryHandler(IClienteAccountRepository customerRepository)
    {
        _clienteRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<ErrorOr<ClientAccountResponse>> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _clienteRepository.GetByIdAsync(new PersonaId(query.Id)) is not ClienteAccount client)
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        return new ClientAccountResponse(
            client.PersonaId.Value,
            client.Nombre,
            client.Genero,
            client.Edad,
            client.Identificacion,
            new DireccionResponse(client.Direccion.Ciudad, client.Direccion.Calle),
            client.Telefono,
            client.Estado
            );
    }
}
