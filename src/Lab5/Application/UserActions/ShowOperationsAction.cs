using Abstractions.Repositories;
using Contracts.UserActions;
using Models.Operation;

namespace Application.UserActions;

public class ShowOperationsAction : IShowOperations
{
    private readonly IOperationsRepository _operationsRepository;

    public ShowOperationsAction(IOperationsRepository operationsRepository)
    {
        _operationsRepository = operationsRepository;
    }

    public IAsyncEnumerable<Operation> ShowOperations(long id)
    {
        return _operationsRepository.GetAllCardsOperations(id);
    }
}