using Domain.Primitive;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Movement : AggregateRoot
{
    [Key]
    public MovementId MovementId { get; set; }
    public DateTime Fecha { get; set; }
    public string TipoMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public AccountID AccountFk { get; set; } // This is the foreign key

    public string descripcion
    {
        get { return $"{TipoMovimiento} de {Valor}"; }
    }

    //por entityframework
    public Movement()
    {

    }

    public Movement(DateTime fecha, string tipoMovimiento, decimal valor, decimal saldo, AccountID accountFk)
    {
        MovementId = new MovementId(Guid.NewGuid());
        Fecha = fecha;
        TipoMovimiento = tipoMovimiento;
        Valor = valor;
        Saldo = saldo;
        AccountFk = accountFk;
    }
}
    

