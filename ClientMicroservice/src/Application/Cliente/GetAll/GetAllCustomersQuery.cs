using Application.Cliente;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll;

public record GetAllClientQuery() : IRequest<ErrorOr<IReadOnlyList<ClientAccountResponse>>>;