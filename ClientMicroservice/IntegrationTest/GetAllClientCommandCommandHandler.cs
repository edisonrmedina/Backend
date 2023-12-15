using Application.Cliente;
using Application.Customers.GetAll;
using Domain;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTest.Application
{
    public  class GetAllClientCommandCommandHandler
    {
        [Fact]
        public async Task Handle_GetAllClientQuery_ShouldReturnListOfClientAccountResponsesAsync()
        {
            // Arrange
            var mockRepository = new Mock<IClienteAccountRepository>();
            var queryHandler = new GetAllClientsQueryHandler(mockRepository.Object);

            // Configurar el comportamiento simulado del repositorio
            var cliente1 = new ClienteAccount
            {
                PersonaId = new PersonaId(),
                Contraseña = "password123",
                Estado = true,
                Nombre = "John Doe",
                Genero = "Male",
                Edad = 30,
                Identificacion = "ABC123",
                Direccion = new Direccion("City1", "Street1"),
                Telefono = "123456789"
            };
            var cliente2 = new ClienteAccount
            {
                PersonaId = new PersonaId(),
                Contraseña = "pass456",
                Estado = false,
                Nombre = "Jane Doe",
                Genero = "Female",
                Edad = 25,
                Identificacion = "XYZ456",
                Direccion = new Direccion("City2", "Street2"),
                Telefono = "987654321"
            };

            var clientesSimulados = new List<ClienteAccount>
            {
                cliente1,
                cliente2
            };

            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(clientesSimulados);

            // Act
            var queryResult = await queryHandler.Handle(new GetAllClientQuery(), CancellationToken.None);

            // Assert
            queryResult.IsError.Should().BeFalse();
            queryResult.Value.Should().NotBeNull();
            queryResult.Value.Should().BeAssignableTo<IReadOnlyList<ClientAccountResponse>>();

            var clientResponses = queryResult.Value.Cast<ClientAccountResponse>().ToList();
            clientResponses.Should().HaveCount(clientesSimulados.Count);

            // Agregar más aserciones según sea necesario
        }
    }
}
