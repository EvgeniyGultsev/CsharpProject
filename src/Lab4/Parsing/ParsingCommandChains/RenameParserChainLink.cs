using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public class RenameParserChainLink : ParsingCommandChainLinkBase
{
    private readonly IParsingChain<FileRenameBuilder> _parser;

    public RenameParserChainLink(IParsingChain<FileRenameBuilder> parser)
    {
        _parser = parser;
    }

    public override ParsingResult Handle(IEnumerator<string> word)
    {
        if (word.Current.ToLower(CultureInfo.CurrentCulture) == "rename")
        {
            var fileRenameBuilder = new FileRenameBuilder();

            while (word.MoveNext())
            {
                ParsingArgumentResult result = _parser.Handle(word, fileRenameBuilder);
                if (result is ParsingArgumentResult.Fail)
                    return new ParsingResult.Fail();
            }

            return new ParsingResult.Success(new FileRenameCommand(fileRenameBuilder.Build()));
        }

        return Next is null ? new ParsingResult.Fail() : Next.Handle(word);
    }
}