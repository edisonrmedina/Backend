namespace Infrastructure;

public record ClientAccountResponse(
Guid id,
string name,
string genero,
int edad,
string identificacion,
DireccionResponse direccion,
string telefono,
bool estado);

public record DireccionResponse(
    string ciudad,
    string calle
    );