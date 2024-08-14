using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class MoveParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<FileMoveBuilder> _parser;

    public MoveParserChainLink(IParsingChain<FileMoveBuilder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "move")
        {
            var fileMoveBuilder = new FileMoveBuilder();
            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, fileMoveBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new FileMoveCommand(fileMoveBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}