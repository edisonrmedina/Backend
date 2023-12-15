using Domain;

namespace Application.Cliente;

public record AccountResponse(
AccountID AccountID,
string TipoCuenta,
decimal SaldoInicial,
bool Estado,
List<MovementResponse> Movements,
Guid ClientId
);

