using Application;
using Application.Customers.Update;
using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;

namespace Application
{
    internal sealed class UpdateMovementCommandHandler1 : IRequestHandler<UpdateAccountCommand, ErrorOr<Unit>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMovementCommandHandler1(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            // Obtener la cuenta actual desde el repositorio
            Account currentAccount = await _accountRepository.GetByIdAsync(command.AccountID);

            if (currentAccount == null)
            {
                return Error.NotFound("Customer.NotFound", "The account with the provided Id was not found.");
            }

            currentAccount.TipoCuenta = command.TipoCuenta;
            currentAccount.Estado = command.Estado;
            _accountRepository.Update(currentAccount);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
