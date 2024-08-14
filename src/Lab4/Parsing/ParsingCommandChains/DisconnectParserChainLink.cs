using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class DisconnectParserChainLink : ParsingCommandChainLinkBase
{
    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "disconnect")
        {
            var disconnectBuilder = new DisconnectModel.Builder();
            return new ParsingResult.Success(new DisconnectCommand(disconnectBuilder.Build()));
        }
        else
        {
            return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
        }
    }
}