using Domain;
using FluentValidation;

namespace Application.Customers.Delete;

public class DeleteAccountClienteCommandValidator : AbstractValidator<Movement>
{
    public DeleteAccountClienteCommandValidator()
    {
        RuleFor(r => r.MovementId.Value)
            .NotEmpty();
    }
}