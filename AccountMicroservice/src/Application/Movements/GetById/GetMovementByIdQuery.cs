using Application.Cliente;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;

public record GetMovementByIdQuery(Guid Id) : IRequest<ErrorOr<MovementResponse>>;