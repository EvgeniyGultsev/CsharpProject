using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileMoveParser;

public class FileMovePathParser : IParsingChain<FileMoveBuilder>
{
    private IParsingChain<FileMoveBuilder>? _next;
    public void AddNext(IParsingChain<FileMoveBuilder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, FileMoveBuilder builder)
    {
        if (command.Current[0] != '-')
        {
            builder.WithSourcePath(command.Current);
            return new ParsingArgumentResult.Success();
        }

        if (_next is not null)
            return _next.Handle(command, builder);
        return new ParsingArgumentResult.Fail();
    }
}