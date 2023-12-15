    using Domain;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ClienteAccount : Persona
{
   
    private string estado { get; set; }
    private string nombre { get; set; }
    private string genero { get; set; }
    private int edad { get; set; }
    private string identificacion { get; set; }
    private Direccion direccion { get; set; }
    private string telefono { get; set; }
    public string Contraseña { get;  set; }
    public bool Estado { get;  set; }

    public ClienteAccount(
    string contraseña,
    bool estado,
    string nombre,
    string genero,
    int edad,
    string identificacion,
    Direccion direccion,
    string telefono
) : this(new PersonaId(Guid.NewGuid()), contraseña, estado, nombre, genero, edad, identificacion, direccion, telefono)
    {
    }

    public ClienteAccount(
        PersonaId personaId,
        string contraseña,
        bool estado,
        string nombre,
        string genero,
        int edad,
        string identificacion,
        Direccion direccion,
        string telefono
    ) : base(
          personaId,
          nombre,
          genero,
          edad,
          identificacion,
          direccion,
          telefono
    )
    {
        Contraseña = contraseña;
        Estado = estado;
    }


    public ClienteAccount() { }

}


