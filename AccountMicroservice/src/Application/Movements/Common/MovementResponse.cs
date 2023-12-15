using Domain;

namespace Application;

public record MovementResponse(
MovementId MovementId,
DateTime Fecha,
string TipoMovimiento,
decimal Valor,
decimal Saldo,
string Descripcion
    );

