using Application.Reporte;
using Domain;
using Domain.Primitive;
using ErrorOr;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cliente
{
    public sealed class CreateCommandReportHandler : IRequestHandler<CreateCommandReport, ErrorOr<string>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMovementRepository _movementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientProx _clientProx;

        public CreateCommandReportHandler(
            IAccountRepository accountRepository,
            IMovementRepository movementRepository,
            IUnitOfWork unitOfWork,
            IClientProx clientProxy
            )
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _movementRepository = movementRepository ?? throw new ArgumentNullException(nameof(movementRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _clientProx = clientProxy;
        }

        public async Task<ErrorOr<string>> Handle(CreateCommandReport request, CancellationToken cancellationToken)
        {
            try
            {
                // Obtener la lista de cuentas asociadas al cliente
                var cuentaIds = await _accountRepository.getAllByClientId(request.ClienteId);

                // Obtener movimientos en el rango de fechas
                List<Movement> movements = await _movementRepository.GetMovimientosByDateRangeAndAccountsAsync(request.FechaInicio, request.FechaFin, cuentaIds);

                // Obtener la información del cliente
                var jsonResponse = await _clientProx.createClientAsync(new GetAccountByIdQuery(request.ClienteId));
                var cliente = JsonSerializer.Deserialize<ClientAccountResponse>(jsonResponse);
                var nombreCliente = cliente.name;

                // Crear un nuevo objeto que contiene tanto los movimientos como el nombre del cliente
                var resultObject = new
                {
                    Movements = movements,
                    ClienteName = nombreCliente
                };

                // Serializar el objeto resultante a formato JSON
                string jsonContent = JsonSerializer.Serialize(resultObject);

                // Realizar la confirmación de la unidad de trabajo si todo va bien.
                await _unitOfWork.SaveChangesAsync();

                // Devolver el resultado en formato JSON
                return jsonContent;
            }
            catch (Exception ex)
            {
                // Devolver un objeto de error detallado en caso de excepción
                return Error.Failure("CreateClienteAccount.Failure", $"Error: {ex.GetType().Name}, Message: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            finally
            {
                // Liberar recursos que implementan IDisposable
                (_unitOfWork as IDisposable)?.Dispose();
            }

        }
    }
}
