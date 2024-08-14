using System.Diagnostics.CodeAnalysis;
using Contracts.AdminActions;
using Contracts.Logging;
using Models.User;

namespace Console.Scenarios.AdminOperations.MakeNewCard;

public class AdminMakeNewCardScenarioProvider : IScenarioProvider
{
    private readonly IAddUser _addUser;
    private readonly ICurrentUserManager _currentUser;

    public AdminMakeNewCardScenarioProvider(IAddUser addUser, ICurrentUserManager currentUserManager)
    {
        _addUser = addUser;
        _currentUser = currentUserManager;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is User.Admin)
        {
            scenario = new AdminMakeNewCardScenario(_addUser);
            return true;
        }

        scenario = null;
        return false;
    }
}