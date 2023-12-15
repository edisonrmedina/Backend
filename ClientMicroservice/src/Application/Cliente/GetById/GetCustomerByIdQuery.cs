using Application.Cliente;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;

public record GetClientByIdQuery(Guid Id) : IRequest<ErrorOr<ClientAccountResponse>>;