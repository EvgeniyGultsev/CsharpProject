using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class GoToParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<TreeGoToModel.Builder> _parser;

    public GoToParserChainLink(IParsingChain<TreeGoToModel.Builder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "goto")
        {
            var treeGoToBuilder = new TreeGoToModel.Builder();

            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, treeGoToBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new TreeGoToCommand(treeGoToBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}