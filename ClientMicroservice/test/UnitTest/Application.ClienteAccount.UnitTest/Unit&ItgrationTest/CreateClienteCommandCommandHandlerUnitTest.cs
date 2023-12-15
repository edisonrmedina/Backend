using Application.Cliente;
using Application.Customers.Create;
using Application.Customers.Update;
using Domain;
using Domain.Primitive;
using ErrorOr;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Application
{
    public class CreateClienteCommandCommandHandlerUnitTest
    {
        private readonly Mock<IClienteAccountRepository> _mockCustomerRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateClienteCommandCommandHandler _handler;

        public CreateClienteCommandCommandHandlerUnitTest()
        {
            _mockCustomerRepository = new Mock<IClienteAccountRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateClienteCommandCommandHandler(_mockCustomerRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreatClienteAccount_WhenDireccionIsNotComplete_ShouldReturnValidationErrorAsync()
        {
            // Arrange
            CreateClienteAccountCommand command = new CreateClienteAccountCommand(
                Contraseña: "123456",
                Estado: true,
                Nombre: "John Doe",
                Genero: "Male",
                Edad: 25,
                Identificacion: "ABC123",
                Ciudad: "", // Ciudad vacía para hacer que la dirección no esté completa
                Calle: "Main St",
                Telefono: "123456789"
            );

            // Act

            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);

            // Agregar más aserciones según sea necesario
        }
       
    }
}
