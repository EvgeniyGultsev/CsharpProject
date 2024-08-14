using System.Collections.Generic;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class TreeParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingCommandChainLink _command;
    public TreeParserChainLink(IParsingCommandChainLink command)
    {
        _command = command;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "tree")
        {
            if (word.MoveNext() is false)
                return new ParsingResult.Fail();
            return _command.Handle(word);
        }
        else
        {
            return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
        }
    }
}