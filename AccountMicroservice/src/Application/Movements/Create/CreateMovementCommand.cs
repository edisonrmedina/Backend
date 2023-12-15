using Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

   public record class CreateMovementCommand(
     DateTime Fecha,
     string TipoMovimiento,
     decimal Valor,
     decimal Saldo,
     AccountID AccountFk
     ) : IRequest<ErrorOr<Unit>>;

