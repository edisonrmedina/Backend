using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comunication.Model
{
    public class ClientCreateRequest
    {
        public int Id { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
