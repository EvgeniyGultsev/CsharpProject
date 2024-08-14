namespace Contracts.UserActions;

public interface IShowMoney
{
    Task<decimal> ShowMoney(long id);
}