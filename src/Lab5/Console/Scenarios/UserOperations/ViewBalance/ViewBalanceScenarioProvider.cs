using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.UserActions;
using Models.User;

namespace Console.Scenarios.UserOperations.ViewBalance;

public class ViewBalanceScenarioProvider : IScenarioProvider
{
    private readonly IShowMoney _showMoney;
    private readonly ICurrentUserManager _currentUser;

    public ViewBalanceScenarioProvider(IShowMoney showMoney, ICurrentUserManager currentUser)
    {
        _showMoney = showMoney;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is User.Card user)
        {
            scenario = new ViewBalanceScenario(_showMoney, user.CardId);
            return true;
        }

        scenario = null;
        return false;
    }
}