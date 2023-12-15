using Domain;
using Domain.Primitive;
using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

public sealed class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ErrorOr<Unit>>
{
    private readonly IClienteAccountRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteClientCommandHandler(IClienteAccountRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteClientCommand command, CancellationToken cancellationToken)
    {
        if (await _clienteRepository.GetByIdAsync(new PersonaId(command.Id)) is not ClienteAccount cliente)
        {
            return Error.NotFound("Cliente.NotFound", "The client with the provide Id was not found.");
        }

        _clienteRepository.Delete(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
