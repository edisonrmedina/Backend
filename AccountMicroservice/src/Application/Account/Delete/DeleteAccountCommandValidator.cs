using FluentValidation;

namespace Application.Customers.Delete;

public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}