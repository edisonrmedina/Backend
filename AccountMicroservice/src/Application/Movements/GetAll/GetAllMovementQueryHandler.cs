using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Application;


internal sealed class GetAllMovementQueryHandler : IRequestHandler<GetAllMovementQuery, ErrorOr<IReadOnlyList<MovementResponse>>>
{
    private readonly IMovementRepository _movementRepository;

    public GetAllMovementQueryHandler(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository ?? throw new ArgumentNullException(nameof(movementRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<MovementResponse>>> Handle(GetAllMovementQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Movement> movements  = await _movementRepository.GetAll();

        return movements.Select(movement => new MovementResponse(
                movement.MovementId,
                movement.Fecha,
                movement.TipoMovimiento,
                movement.Valor,
                movement.Saldo,
                movement.descripcion
            )).ToList();
    }
}