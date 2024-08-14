using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class DeleteParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<FileDeleteModel.Builder> _parser;

    public DeleteParserChainLink(IParsingChain<FileDeleteModel.Builder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "delete")
        {
            var fileDeleteBuilder = new FileDeleteModel.Builder();
            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, fileDeleteBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new FileDeleteCommand(fileDeleteBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}