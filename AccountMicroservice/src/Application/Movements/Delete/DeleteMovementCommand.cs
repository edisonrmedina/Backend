using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

public record DeleteMovementCommand(Guid Id) : IRequest<ErrorOr<Unit>>;