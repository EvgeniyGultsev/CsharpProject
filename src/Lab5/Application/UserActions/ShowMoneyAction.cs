using Abstractions.Repositories;
using Contracts.UserActions;

namespace Application.UserActions;

public class ShowMoneyAction : IShowMoney
{
    private readonly ICardRepository _cardRepository;

    public ShowMoneyAction(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public Task<decimal> ShowMoney(long id)
    {
        return _cardRepository.ShowBalanceById(id);
    }
}