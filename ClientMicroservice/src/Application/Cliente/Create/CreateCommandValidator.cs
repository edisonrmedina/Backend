using Domain;
using FluentValidation;

namespace Application.Customers.Create;

public class CreateCustomerCommandValidator : AbstractValidator<ClienteAccount>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(r => r.Nombre)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Nombre");

        RuleFor(r => r.Genero)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Genero");

        RuleFor(r => r.Direccion.Calle)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Direccion.Calle");

        RuleFor(r => r.Direccion.Ciudad)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Direccion.Ciudad");

        RuleFor(r => r.Edad)
            .GreaterThanOrEqualTo(0)
            .WithName("Edad");

        RuleFor(r => r.Identificacion)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Identificacion");

        RuleFor(r => r.Contraseña)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(50)
            .WithName("Contraseña");
    }
}