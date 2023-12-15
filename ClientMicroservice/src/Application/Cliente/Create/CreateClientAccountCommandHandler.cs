using Domain;
using Domain.Primitive;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace Application.Cliente
{
    public sealed class CreateClienteCommandCommandHandler : IRequestHandler<CreateClienteAccountCommand, ErrorOr<Unit>>
    {

        private readonly IClienteAccountRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClienteCommandCommandHandler(
            IClienteAccountRepository clienteRepository,
            IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); ;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateClienteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Crear una instancia de Direccion utilizando los datos del comando
                if (Direccion.Create(request.Calle, request.Ciudad) is not Direccion direccion)
                { 
                    return Error.Validation("Cliente.Dirreccion", "Error en la validación para dirección");
                }
                else
                {
                    if (direccion.Calle.Length == 0)
                    {
                        return Error.Validation("Cliente.Calle", "Error en la longitud de Ciudad");
                    }
                    else if (direccion.Ciudad.Length == 0)
                    {
                        return Error.Validation("Cliente.Ciudad", "Error en la longitud de Ciudad");
                    }
                }

                // Crear una instancia de Cliente utilizando los datos del comando
                var cliente = new ClienteAccount(
                    contraseña: request.Contraseña,
                    estado: true,
                    nombre: request.Nombre,
                    genero: request.Genero,
                    edad: request.Edad,
                    identificacion: request.Identificacion,
                    direccion: direccion,
                    telefono:request.Telefono
                );

                // Agregar la nueva instancia de Cliente al repositorio
                _clienteRepository.Add(cliente);

                // Guardar los cambios en la unidad de trabajo
                await _unitOfWork.SaveChangesAsync();

                // Devolver el resultado exitoso
                return Unit.Value; //ver aca que devuelva de manera correcta
            }
            catch (Exception ex)
            {
                return Error.Failure("CreateClienteAccount.Failure", ex.Message);
            }
        }
    }
}
