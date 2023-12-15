using Domain.Primitive;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Persona : AggregateRoot
{
    [Key]
    public PersonaId PersonaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string Identificacion { get; set; } = string.Empty;
    public Direccion Direccion { get; set; }
    public string Telefono { get;  set; } = string.Empty;
    
    public Persona(PersonaId personaId, string nombre, string genero, int edad, string identificacion, Direccion direccion, string telefono)
    {
        PersonaId = new PersonaId(Guid.NewGuid());
        Nombre = nombre;
        Genero = genero;
        Edad = edad;
        Identificacion = identificacion;
        Direccion = direccion;
        Telefono = telefono;
    }

    //por entityframework
    public Persona()
    {

    }

}
    

