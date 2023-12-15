namespace Application.Cliente;

public record ClientAccountResponse(
Guid Id,
string Name,
string Genero,
int Edad,
string Identificacion,
DireccionResponse Direccion,
string Telefono,
bool Estado);

public record DireccionResponse(
    string Ciudad,
    string Calle
    );