using Application.Cliente;
using ErrorOr;
using MediatR;

namespace Application;

public record GetAllMovementQuery() : IRequest<ErrorOr<IReadOnlyList<MovementResponse>>>;