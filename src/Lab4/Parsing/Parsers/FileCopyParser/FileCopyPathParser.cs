using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileCopyParser;

public class FileCopyPathParser : IParsingChain<FileCopyBuilder>
{
    private IParsingChain<FileCopyBuilder>? _next;
    public void AddNext(IParsingChain<FileCopyBuilder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, FileCopyBuilder builder)
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