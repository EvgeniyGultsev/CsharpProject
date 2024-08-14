using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.UserActions;
using Models.User;

namespace Console.Scenarios.UserOperations.SubtractMoney;

public class SubtractMoneyScenarioProvider : IScenarioProvider
{
    private readonly ISubtractMoney _subtractMoney;
    private readonly ICurrentUserManager _currentUser;

    public SubtractMoneyScenarioProvider(ISubtractMoney subtractMoney, ICurrentUserManager currentUser)
    {
        _subtractMoney = subtractMoney;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is User.Card user)
        {
            scenario = new SubtractMoneyScenario(_subtractMoney, user.CardId);
            return true;
        }

        scenario = null;
        return false;
    }
}