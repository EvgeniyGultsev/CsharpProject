using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.ConnectParser;

public class ConnectMFlagParser : IParsingChain<ConnectModel.Builder>
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
        if (command.Current == "-m")
        {
            if (command.MoveNext())
            {
                if (command.Current.ToLower(CultureInfo.CurrentCulture) == "local")
                    builder.WithMFlag(Mode.Local);
                else
                    return new ParsingArgumentResult.Fail();
                return new ParsingArgumentResult.Success();
            }

            return new ParsingArgumentResult.Fail();
        }

        if (_next is not null)
            return _next.Handle(command, builder);
        return new ParsingArgumentResult.Fail();
    }
}