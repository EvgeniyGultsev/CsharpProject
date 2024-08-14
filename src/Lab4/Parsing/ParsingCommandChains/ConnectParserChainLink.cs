using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class ConnectParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<ConnectModel.Builder> _parser;

    public ConnectParserChainLink(IParsingChain<ConnectModel.Builder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "connect")
        {
            var connectBuilder = new ConnectModel.Builder();
            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, connectBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new ConnectCommand(connectBuilder.Build()));
        }
        else
        {
            return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
        }
    }
}