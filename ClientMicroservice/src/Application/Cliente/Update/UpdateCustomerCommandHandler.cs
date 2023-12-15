using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers;
using Domain;
using Domain.Primitive;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateClientCommand, ErrorOr<Unit>>
    {
        private readonly IClienteAccountRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IClienteAccountRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _clienteRepository.ExistsAsync(new PersonaId(command.Id)))
                {
                    return Error.NotFound("Customer.NotFound", "The customer with the provided Id was not found.");
                }

                Direccion direccion = null;

                if (string.IsNullOrEmpty(command.Calle) || string.IsNullOrEmpty(command.Ciudad))
                {
                    // Modificar para manejar la dirección (Calle, Ciudad, etc.)
                    if (Direccion.Create(command.Calle, command.Ciudad) is not Direccion createdDireccion)
                    {
                        return Error.Validation("Customer.Direccion", "Address is not valid.");
                    }

                    direccion = createdDireccion;
                }

                ClienteAccount cliente = new ClienteAccount(
                    command.contraseña, // La contraseña no está en el comando de actualización
                    command.Estado,
                    command.Name,
                    command.Genero,
                    command.Edad,
                    command.Identificacion,
                    direccion,
                    command.Telefono
                );

                cliente.PersonaId = new PersonaId(command.Id); // Asumiendo que PersonaId está en ClienteAccount

                _clienteRepository.Update(cliente);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex) {
                return Error.Failure("UpdateClienteAccount.Failure", ex.Message);
            }
        }
    }
}
