using Domain.Primitive;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Account : AggregateRoot
{
    [Key]
    public AccountID AccountID { get; set; }
    public string TipoCuenta { get; set; }
    public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; }

    public Guid ClienteId { get; set; }
    public List<Movement> Movimentos { get; set; }
    
    

    public Account( string tipoCuenta, decimal saldoInicial, bool estado,Guid clientId)
    {
        AccountID = new AccountID(Guid.NewGuid());
        TipoCuenta = tipoCuenta;
        SaldoInicial = saldoInicial;
        Estado = estado;
        Movimentos = new List<Movement>();
        ClienteId = clientId;
    }
    public Account() { }
}


