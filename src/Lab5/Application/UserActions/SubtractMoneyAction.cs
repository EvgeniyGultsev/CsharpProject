using Abstractions.Repositories;
using Contracts;
using Contracts.UserActions;
using Models.Operation;

namespace Application.UserActions;

public class SubtractMoneyAction : ISubtractMoney
{
    private readonly ICardRepository _cardRepository;
    private readonly IOperationsRepository _operationsRepository;

    public SubtractMoneyAction(ICardRepository cardRepository, IOperationsRepository operationsRepository)
    {
        _cardRepository = cardRepository;
        _operationsRepository = operationsRepository;
    }

    public async Task<OperationResult> SubtractMoney(long id, decimal amount)
    {
        if (await _cardRepository.ShowBalanceById(id) < amount)
        {
            return new OperationResult.Fail();
        }

        await _operationsRepository.AddOperation(id, new Operation(OperationType.Subtract, amount));
        return await _cardRepository.SubtractMoney(id, amount);
    }
}