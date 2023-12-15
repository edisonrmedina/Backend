
using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;


internal sealed class GetMovementByIdQueryHandler: IRequestHandler<GetMovementByIdQuery, ErrorOr<MovementResponse>>
{
    private readonly IMovementRepository _movementRepository;

    public GetMovementByIdQueryHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository ?? throw new ArgumentNullException(nameof(movementRepository));
    }

    public async Task<ErrorOr<MovementResponse>> Handle(GetMovementByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _movementRepository.GetByIdAsync(new MovementId(query.Id)) is not Movement movement)
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        return new MovementResponse(
                movement.MovementId,
                movement.Fecha,
                movement.TipoMovimiento,
                movement.Valor,
                movement.Saldo,
                movement.descripcion
            );
    }
}
