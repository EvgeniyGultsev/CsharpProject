namespace Contracts.UserActions;

public interface ISubtractMoney
{
    Task<OperationResult> SubtractMoney(long id, decimal amount);
}