using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reporte
{
    public class Report
    {
        public string ClienteNombre { get; set; }
        public List<Account> Cuentas { get; set; }
    }
}
