using Application.Customers.Update;

namespace Application.UnitTest.Application
{
    public class UpdateClienteCommandCommandHandler
    {

        public UpdateClienteCommandCommandHandler()
        {
        }

        [Fact]
        public async Task UpdateCustomerCommandValidator_WhenNameExceedsMaximumLength_ShouldHaveError()
        {
            // Arrange
            var validator = new UpdateCustomerCommandValidator();
            var command = new UpdateClientCommand(
                Id: new Guid("07D0531A-481D-49C7-93CE-AAA9FDC8E9B0"),
                contraseña: "123456",
                Name: "ThisNameIsTooLongAndExceedsMaximumLengthThisNameIsTooLongAndExceedsMaximumLength", // Name exceeds maximum length
                Identificacion: "ABC123",
                Genero: "Male",
                Edad: 25,
                Estado: true,
                Ciudad: "City",
                Calle: "Main St",
                Telefono: "123456789"
            );

            // Act
            var validationResult = validator.Validate(command);
            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle(error => error.PropertyName == "Name");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorCode == "MaximumLengthValidator");
        }

    }
}
