using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public partial record Direccion
    {
        public Direccion(string calle, string ciudad)
        {
            Calle = calle;
            Ciudad = ciudad;
        }

        public string Calle { get; init; }
        public string Ciudad { get; init; }

        public static Direccion? Create(string calle, string ciudad)
        {
            return new Direccion(calle, ciudad);
        }
    }
}
