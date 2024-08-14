using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class CopyParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<FileCopyBuilder> _parser;

    public CopyParserChainLink(IParsingChain<FileCopyBuilder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "copy")
        {
            var fileCopyBuilder = new FileCopyBuilder();

            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, fileCopyBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new FileCopyCommand(fileCopyBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}