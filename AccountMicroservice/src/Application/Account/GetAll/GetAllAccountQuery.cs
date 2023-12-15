using Application.Cliente;
using ErrorOr;
using MediatR;

namespace Application;

public record GetAllAccountQuery() : IRequest<ErrorOr<IReadOnlyList<AccountResponse>>>;