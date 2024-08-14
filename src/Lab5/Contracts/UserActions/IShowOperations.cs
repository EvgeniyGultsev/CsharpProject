using Models.Operation;

namespace Contracts.UserActions;

public interface IShowOperations
{
    IAsyncEnumerable<Operation> ShowOperations(long id);
}