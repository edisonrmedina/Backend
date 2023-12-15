using Domain;
using FluentValidation;

namespace Application.Customers.Update;

public class UpdateMovementCommandValidator : AbstractValidator<Account>
{
    public UpdateMovementCommandValidator()
    {
        RuleFor(r => r.TipoCuenta)
        .NotEmpty()
        .MaximumLength(50)
        .Must(tipo => tipo == "Ahorro" || tipo == "Corriente")
        .WithMessage("El campo Genero solo puede tener los valores 'Ahorro' o 'Corriente'")
        .WithName("Genero");

        RuleFor(r => r.SaldoInicial)
            .GreaterThanOrEqualTo(0)
            .WithName("SaldoInicial");

        RuleFor(r => r.Estado)
            .NotNull()
            .WithName("Estado"); 
    }
}