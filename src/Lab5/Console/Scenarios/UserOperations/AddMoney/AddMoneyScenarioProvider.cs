using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.UserActions;
using Models.User;

namespace Console.Scenarios.UserOperations.AddMoney;

public class AddMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserManager _currentUser;
    private readonly IAddMoney _addMoney;

    public AddMoneyScenarioProvider(ICurrentUserManager currentUser, IAddMoney addMoney)
    {
        _currentUser = currentUser;
        _addMoney = addMoney;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is User.Card user)
        {
            scenario = new AddMoneyScenario(_addMoney, user.CardId);
            return true;
        }

        scenario = null;
        return false;
    }
}