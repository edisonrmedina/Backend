using Application.Cliente;
using ErrorOr;
using MediatR;

namespace Application ;

public record GetClientByIdQuery(Guid Id) : IRequest<ErrorOr<AccountResponse>>;