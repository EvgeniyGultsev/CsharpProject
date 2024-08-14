using Contracts;
using Models.User;

namespace Abstractions.Repositories;

public interface ICardRepository
{
     Task<User.Card?> FindCardById(long id);
     Task<OperationResult> AddMoney(long id, decimal amount);
     Task<OperationResult> SubtractMoney(long id, decimal amount);
     Task<decimal> ShowBalanceById(long id);
}