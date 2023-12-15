using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Application;
internal sealed class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, ErrorOr<IReadOnlyList<AccountResponse>>>
{
    private readonly IAccountRepository _accountRepository;

    public GetAllAccountQueryHandler(IAccountRepository clienteAccoutRepository)
    {
        _accountRepository = clienteAccoutRepository ?? throw new ArgumentNullException(nameof(clienteAccoutRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<AccountResponse>>> Handle(GetAllAccountQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Account> accounts = await _accountRepository.GetAll();

        return accounts.Select(account => new AccountResponse(
            account.AccountID,
            account.TipoCuenta,
            account.SaldoInicial,
            account.Estado,
            account.Movimentos?.Select(movement => new MovementResponse(
                MovementId: movement.MovementId,
                Fecha: movement.Fecha,
                TipoMovimiento: movement.TipoMovimiento,
                Valor: movement.Valor,
                Saldo: movement.Saldo,
                Descripcion: movement.descripcion
            )).ToList() ?? new List<MovementResponse>(), // Si Movimentos es null, devuelve una lista vacía
            account.ClienteId
        )).ToList();

    }
}