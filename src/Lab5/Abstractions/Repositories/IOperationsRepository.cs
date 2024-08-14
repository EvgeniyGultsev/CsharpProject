using Contracts;
using Models.Operation;

namespace Abstractions.Repositories;

public interface IOperationsRepository
{
    IAsyncEnumerable<Operation> GetAllCardsOperations(long cardId);
    Task<OperationResult> AddOperation(long cardNumber, Operation operation);
}