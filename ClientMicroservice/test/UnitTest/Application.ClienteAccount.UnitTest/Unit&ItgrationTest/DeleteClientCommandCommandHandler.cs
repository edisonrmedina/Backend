using Application.Customers.Delete;
using Application.Customers.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTest.Application
{
    public class DeleteClientCommandCommandHandler
    {


        [Fact]
        public void DeleteCustomerCommandValidator_WhenIdIsEmpty_ShouldHaveError()
        {
            // Arrange
            var validator = new DeleteCustomerCommandValidator();
            var command = new DeleteClientCommand(Guid.Empty); // Proporciona un valor válido para Id

            // Act
            var validationResult = validator.Validate(command);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle(error => error.PropertyName == "Id");
            validationResult.Errors.Should().ContainSingle(error => error.ErrorCode == "NotEmptyValidator");
        }


    }
    
}
