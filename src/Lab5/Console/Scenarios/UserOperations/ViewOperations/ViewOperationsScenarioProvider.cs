using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.UserActions;
using Models.User;

namespace Console.Scenarios.UserOperations.ViewOperations;

public class ViewOperationsScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserManager _currentUser;
    private readonly IShowOperations _showOperations;

    public ViewOperationsScenarioProvider(ICurrentUserManager currentUser, IShowOperations showOperations)
    {
        _currentUser = currentUser;
        _showOperations = showOperations;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is User.Card user)
        {
            scenario = new ViewOperationsScenario(_showOperations, user.CardId);
            return true;
        }

        scenario = null;
        return false;
    }
}