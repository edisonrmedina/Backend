using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;


namespace Application;

public sealed class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, ErrorOr<Unit>>
{

    private readonly IMovementRepository _movementRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountRepository _accountRepository;

    public CreateMovementCommandHandler(
        IMovementRepository movementRepository,
        IAccountRepository accountRepository,
        IUnitOfWork unitOfWork)
    {
        _movementRepository = movementRepository ?? throw new ArgumentNullException(nameof(movementRepository));
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 
    }

    public async Task<ErrorOr<Unit>> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var movement = new Movement(
                fecha: request.Fecha,
                tipoMovimiento: request.TipoMovimiento,
                valor: request.Valor,
                saldo: request.Saldo,
                request.AccountFk
            );


            _movementRepository.Add(movement);

            //actualizo el saldo en mi cuenta
            Account accountFk = await _accountRepository.GetByIdAsync(movement.AccountFk);
            if (accountFk != null)
            {
                // Verificar si es un retiro (negativo) o un depósito (positivo)
                if (movement.Valor < 0 && accountFk.SaldoInicial >= Math.Abs(movement.Valor))
                {
                    // Es un retiro y hay saldo suficiente
                    accountFk.SaldoInicial += movement.Valor; // Restar al saldo porque es una salida de dinero
                    movement.Saldo = accountFk.SaldoInicial;
                }
                else if (movement.Valor >= 0)
                {
                    // Es un depósito
                    accountFk.SaldoInicial += movement.Valor;
                    movement.Saldo = accountFk.SaldoInicial;
                }
                else
                {
                    // No es un depósito y no hay saldo suficiente, lanzar una excepción específica o manejar el error de alguna manera
                    return Error.Failure("CreateMovement.Failure", "Saldo no disponible");
                }

                // Guardar los cambios en la unidad de trabajo
                await _unitOfWork.SaveChangesAsync();

                // Devolver el resultado exitoso
                return Unit.Value;
            }
            else
            {
                return Error.Failure("CreateMovement.Failure", "Account not found");
            }


            // Guardar los cambios en la unidad de trabajo
            await _unitOfWork.SaveChangesAsync();

            // Devolver el resultado exitoso
            return Unit.Value; //ver aca que devuelva de manera correcta
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateMovement.Failure", ex.Message);
        }
    }
}
