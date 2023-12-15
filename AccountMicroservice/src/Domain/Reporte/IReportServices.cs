using Domain.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IReportServicesRepository
    {
        public  Task<Report> GenerarEstadoCuentaReporteAsync(DateTime fechaInicio, DateTime fechaFin, Guid clienteId);
    }
}
