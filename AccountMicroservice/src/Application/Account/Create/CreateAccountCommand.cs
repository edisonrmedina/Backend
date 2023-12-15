using Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cliente
{
   public record class CreateAccountCommand(
     string TipoCuenta,
     decimal SaldoInicial,
     bool Estado,
     Guid ClienteId
       ) : IRequest<ErrorOr<Unit>>;
}
