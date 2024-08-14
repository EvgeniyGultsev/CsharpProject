using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.ConnectParser;

public class ConnectPathParser : IParsingChain<ConnectModel.Builder>
{
    private IParsingChain<ConnectModel.Builder>? _next;
    public void AddNext(IParsingChain<ConnectModel.Builder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, ConnectModel.Builder builder)
    {
        if (command.Current[0] != '-')
        {
            builder.WithAddress(command.Current);
            return new ParsingArgumentResult.Success();
        }

        if (_next is not null)
            return _next.Handle(command, builder);
        return new ParsingArgumentResult.Fail();
    }
}