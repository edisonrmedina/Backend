using Application.Cliente;
using Application.Customers.GetById;
using Domain;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTest.Unit
{
    public class GetClientByIdCommandHandlerUnitTest
    {
        [Fact]
        public async Task Handle_GetClientByIdQuery_ShouldReturnClientAccountResponseAsync()
        {
            // Arrange
            var mockRepository = new Mock<IClienteAccountRepository>();
            var queryHandler = new GetClientByIdQueryHandler(mockRepository.Object);

            // ID de cliente simulado
            var clientId = new PersonaId();

            // Configurar el comportamiento simulado del repositorio para obtener un cliente por ID
            var cliente = new ClienteAccount
            {
                PersonaId = clientId,
                Contraseña = "password123",
                Estado = true,
                Nombre = "John Doe",
                Genero = "Male",
                Edad = 30,
                Identificacion = "ABC123",
                Direccion = new Direccion("City1", "Street1"),
                Telefono = "123456789"
            };

            mockRepository.Setup(repo => repo.GetByIdAsync(clientId)).ReturnsAsync(cliente);

            // Act
            var queryResult = await queryHandler.Handle(new GetClientByIdQuery(clientId.Value), CancellationToken.None);

            // Assert
            queryResult.IsError.Should().BeFalse();
            queryResult.Value.Should().NotBeNull();
            queryResult.Value.Should().BeAssignableTo<ClientAccountResponse>();

            var clientResponse = queryResult.Value;

            // Realiza aserciones específicas del cliente obtenido
            clientResponse.Name.Should().Be("John Doe");
            clientResponse.Identificacion.Should().Be("ABC123");

        }
    }
}
