using Abstractions.Repositories;
using Contracts;
using Contracts.UserActions;
using Models.Operation;

namespace Application.UserActions;

public class AddMoneyAction : IAddMoney
{
    private readonly ICardRepository _cardRepository;
    private readonly IOperationsRepository _operationsRepository;

    public AddMoneyAction(ICardRepository cardRepository, IOperationsRepository operationsRepository)
    {
        _cardRepository = cardRepository;
        _operationsRepository = operationsRepository;
    }

    public async Task<OperationResult> AddMoney(long cardId, decimal amount)
    {
        await _operationsRepository.AddOperation(cardId, new Operation(OperationType.Add, amount));
        return await _cardRepository.AddMoney(cardId, amount);
    }
}