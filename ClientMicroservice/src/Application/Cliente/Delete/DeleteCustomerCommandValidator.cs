using FluentValidation;

namespace Application.Customers.Delete;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteClientCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}