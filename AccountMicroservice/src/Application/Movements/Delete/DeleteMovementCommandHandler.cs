using Application.Customers.Delete;
using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;

namespace Application;

internal sealed class DeleteClientCommandHandler : IRequestHandler<DeleteMovementCommand, ErrorOr<Unit>>
{
    private readonly IMovementRepository _movementRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteClientCommandHandler(IMovementRepository movementRepository, IUnitOfWork unitOfWork)
    {
        _movementRepository = movementRepository ?? throw new ArgumentNullException(nameof(movementRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteMovementCommand command, CancellationToken cancellationToken)
    {
        if (await _movementRepository.GetByIdAsync(new MovementId(command.Id)) is not Movement movement)
        {
            return Error.NotFound("Movement.NotFound", "The movement with the provide Id was not found.");
        }

        _movementRepository.Delete(movement);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
