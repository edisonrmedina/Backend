using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

public record DeleteAccountCommand(Guid Id) : IRequest<ErrorOr<Unit>>;