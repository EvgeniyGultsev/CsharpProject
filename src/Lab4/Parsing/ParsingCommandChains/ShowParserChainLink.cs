using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class ShowParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<FileShowModel.Builder> _parser;

    public ShowParserChainLink(IParsingChain<FileShowModel.Builder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "show")
        {
            var fileShowBuilder = new FileShowModel.Builder();

            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, fileShowBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new FileShowCommand(fileShowBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}