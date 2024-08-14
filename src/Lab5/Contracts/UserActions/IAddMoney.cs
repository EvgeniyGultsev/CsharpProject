namespace Contracts.UserActions;

public interface IAddMoney
{
    Task<OperationResult> AddMoney(long cardId, decimal amount);
}