using FluentValidation;

namespace Application.Customers.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateCustomerCommandValidator()
    { 
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Genero)
             .NotEmpty()
             .MaximumLength(50)
             .WithName("Genero");

        RuleFor(r => r.Edad).
            NotNull().
            WithName("Edad");

        RuleFor(r => r.Identificacion)
             .NotEmpty()
             .MaximumLength(19)
             .WithName("Identificacion");

        RuleFor(r => r.Ciudad)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(r => r.Calle)
            .NotEmpty()
            .MaximumLength(20)
            .WithName("Addres Line 1");

        

        RuleFor(r => r.Estado)
            .NotNull();
    }
}