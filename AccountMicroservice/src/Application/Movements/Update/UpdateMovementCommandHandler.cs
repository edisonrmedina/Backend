using Application.Customers.Update;
using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;

namespace Application
{
    internal sealed class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, ErrorOr<Unit>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMovementCommandHandler(IMovementRepository movementRepository, IUnitOfWork unitOfWork)
        {
            _movementRepository = movementRepository ?? throw new ArgumentNullException(nameof(movementRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateMovementCommand command, CancellationToken cancellationToken)
        {
            if (!await _movementRepository.ExistsAsync(command.MovementId))
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provided Id was not found.");
            }

            Movement movement = new Movement(
                command.Fecha,
                command.TipoMovimiento,
                command.Valor,
                command.Saldo,
                command.AccountFk
            );

            movement.MovementId = new MovementId(); 

            _movementRepository.Update(movement);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
