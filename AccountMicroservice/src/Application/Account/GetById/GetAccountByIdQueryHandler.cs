
using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;


internal sealed class GetAccountByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ErrorOr<AccountResponse>>
{
    private readonly IAccountRepository _accountRepository;
    
    public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ErrorOr<AccountResponse>> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _accountRepository.GetByIdAsync(new AccountID(query.Id)) is not Account account)
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        return new AccountResponse(
                account.AccountID,
                account.TipoCuenta,
                account.SaldoInicial,
                account.Estado,
                (account.Movimentos ?? new List<Movement>()).Select(movement => new MovementResponse(
                    MovementId: movement.MovementId,
                    Fecha: movement.Fecha,
                    TipoMovimiento: movement.TipoMovimiento,
                    Valor: movement.Valor,
                    Saldo: movement.Saldo,
                    Descripcion: movement.descripcion
                )).ToList(),
                account.ClienteId
            );

    }
}
