using System.Globalization;
using Contracts.UserActions;
using Models.Operation;
using Spectre.Console;

namespace Console.Scenarios.UserOperations.ViewOperations;

public class ViewOperationsScenario : IScenario
{
    private readonly IShowOperations _showOperations;
    private readonly long _id;

    public ViewOperationsScenario(IShowOperations showOperations, long id)
    {
        _showOperations = showOperations;
        _id = id;
    }

    public string Name => "View operations";
    public async Task Run()
    {
        await foreach (Operation operation in _showOperations.ShowOperations(_id))
        {
            AnsiConsole.Write(operation.Type is OperationType.Add ? "+" : "-");
            AnsiConsole.WriteLine(operation.Sum.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.Ask<string>("Ok");
    }
}