using Domain;
using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

public record UpdateMovementCommand(
    MovementId MovementId,
    DateTime Fecha,
    string TipoMovimiento,
    decimal Valor,
    decimal Saldo,
    AccountID AccountFk
    ) : IRequest<ErrorOr<Unit>>;