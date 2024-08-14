using Contracts.AdminActions;
using Spectre.Console;

namespace Console.Scenarios.AdminOperations.MakeNewCard;

public class AdminMakeNewCardScenario : IScenario
{
    private readonly IAddUser _addUser;
    public AdminMakeNewCardScenario(IAddUser addUser)
    {
        _addUser = addUser;
    }

    public string Name => "Make new card";
    public Task Run()
    {
        long cardId = AnsiConsole.Ask<long>("Enter new card id");
        int pinCode = AnsiConsole.Ask<int>("Enter card pin code");

        _addUser.AddUser(cardId, pinCode);

        return Task.CompletedTask;
    }
}