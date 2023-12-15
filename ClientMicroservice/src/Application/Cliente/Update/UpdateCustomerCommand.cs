using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

public record UpdateClientCommand(
    Guid Id,
    string contraseña,
    string Name,
    string Identificacion,
    string Genero,
    int Edad,
    bool Estado,
    string Ciudad,
    string Calle,
    string Telefono
    ) : IRequest<ErrorOr<Unit>>;