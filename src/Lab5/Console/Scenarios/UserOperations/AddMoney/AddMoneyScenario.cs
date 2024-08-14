using Contracts.UserActions;
using Spectre.Console;

namespace Console.Scenarios.UserOperations.AddMoney;

public class AddMoneyScenario : IScenario
{
    private readonly IAddMoney _addMoney;
    private readonly long _id;

    public AddMoneyScenario(IAddMoney addMoney, long id)
    {
        _id = id;
        _addMoney = addMoney;
    }

    public string Name => "Add money";
    public Task Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("How much money to add");
        _addMoney.AddMoney(_id, amount);
        return Task.CompletedTask;
    }
}