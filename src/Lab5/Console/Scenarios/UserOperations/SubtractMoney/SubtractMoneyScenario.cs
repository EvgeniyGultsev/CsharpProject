using Contracts;
using Contracts.UserActions;
using Spectre.Console;

namespace Console.Scenarios.UserOperations.SubtractMoney;

public class SubtractMoneyScenario : IScenario
{
    private readonly ISubtractMoney _subtractMoney;
    private readonly long _id;

    public SubtractMoneyScenario(ISubtractMoney subtractMoney, long id)
    {
        _subtractMoney = subtractMoney;
        _id = id;
    }

    public string Name => "Subtract money";
    public async Task Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("How much money to subtract");

        AnsiConsole.WriteLine(await _subtractMoney.SubtractMoney(_id, amount) is OperationResult.Success
            ? "Subtracted successfully"
            : "Error, didn't subtract");
        AnsiConsole.Ask<string>("Ok");
    }
}