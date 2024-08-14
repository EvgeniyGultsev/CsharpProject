using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileRenameParser;

public class FileRenamePathNameParser : IParsingChain<FileRenameBuilder>
{
    private IParsingChain<FileRenameBuilder>? _next;
    public void AddNext(IParsingChain<FileRenameBuilder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, FileRenameBuilder builder)
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