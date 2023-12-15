using Domain;
using FluentValidation;

namespace Application.Customers.Create;

public class CreateMovementCommandValidator : AbstractValidator<Movement>
{
    public CreateMovementCommandValidator()
    {
        RuleFor(r => r.Fecha)
                .NotNull()
                .WithName("Fecha");

        RuleFor(r => r.TipoMovimiento)
        .NotEmpty()
        .MaximumLength(50)
        .Must(tipo => tipo == "Retiro" || tipo == "Deposito")
        .WithMessage("El campo Genero solo puede tener los valores 'Valor1' o 'Valor2'")
        .WithName("Genero");


        RuleFor(r => r.Valor)
            .NotEmpty()
            .WithName("Valor");

        RuleFor(r => r.Saldo)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithName("Saldo");

    }
}