using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reporte
{
    public record class CreateCommandReport(
             DateTime FechaInicio ,
            DateTime FechaFin ,
            Guid ClienteId
        ): IRequest<ErrorOr<string>>;
}
