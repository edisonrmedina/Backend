using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cliente
{
   public record class CreateClienteAccountCommand(
     string Contraseña,
     bool Estado,
     string Nombre,
     string Genero ,
     int Edad,
     string Identificacion ,
     string Ciudad,
     string Calle,
     string Telefono) : IRequest<ErrorOr<Unit>>;
}
