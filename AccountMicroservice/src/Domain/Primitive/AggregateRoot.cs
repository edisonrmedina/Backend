using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitive
{
    //Agregador de raiz - raices
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new();

        //capturar los eventos de dominio
        public ICollection<DomainEvent> GetDomainEvents()
        {
            return _domainEvents;
        }

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
