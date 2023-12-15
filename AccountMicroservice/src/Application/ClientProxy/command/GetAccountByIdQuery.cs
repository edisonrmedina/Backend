using Application.Cliente;
using Domain;
using ErrorOr;
using MediatR;

namespace Infrastructure;

public class GetAccountByIdQuery
{
    public Guid id;

    public GetAccountByIdQuery(Guid id)
    {
        this.id = id;
    }
}