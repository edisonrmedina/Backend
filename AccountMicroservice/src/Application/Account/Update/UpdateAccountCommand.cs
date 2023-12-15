using Domain;
using ErrorOr;
using MediatR;

namespace Application;

public record UpdateAccountCommand(
    AccountID AccountID,
    string TipoCuenta,
    bool Estado
    
    ) : IRequest<ErrorOr<Unit>>;