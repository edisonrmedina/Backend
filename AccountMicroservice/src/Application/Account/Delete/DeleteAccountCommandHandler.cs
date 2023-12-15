using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

internal sealed class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, ErrorOr<Unit>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteAccountCommandHandler(IAccountRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
    {
        if (await _accountRepository.GetByIdAsync(new AccountID(command.Id)) is not Account cliente)
        {
            return Error.NotFound("Cliente.NotFound", "The client with the provide Id was not found.");
        }

        _accountRepository.Delete(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
