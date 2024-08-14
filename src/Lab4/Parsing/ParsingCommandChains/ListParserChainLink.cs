using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class ListParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<TreeListModel.Builder> _parser;

    public ListParserChainLink(IParsingChain<TreeListModel.Builder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "list")
        {
            var treeListBuilder = new TreeListModel.Builder();

            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, treeListBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new TreeListCommand(treeListBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}