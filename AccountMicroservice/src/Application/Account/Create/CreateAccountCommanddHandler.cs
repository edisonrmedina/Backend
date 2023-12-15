using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;


namespace Application.Cliente
{
    public sealed class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, ErrorOr<Unit>>
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountCommandHandler(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); ;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cuenta = new Account(
                    tipoCuenta: request.TipoCuenta,
                    saldoInicial: request.SaldoInicial,
                    estado: request.Estado,
                    clientId: request.ClienteId
                    );

                // Agregar la nueva instancia de Cliente al repositorio
                _accountRepository.Add(cuenta);

                // Guardar los cambios en la unidad de trabajo
                await _unitOfWork.SaveChangesAsync();

                // Devolver el resultado exitoso
                return Unit.Value; //ver aca que devuelva de manera correcta
            }
            catch (Exception ex)
            {
                return Error.Failure("CreateClienteAccount.Failure", ex.Message);
            }
        }
    }
}
