using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

public record DeleteClientCommand(Guid Id) : IRequest<ErrorOr<Unit>>;