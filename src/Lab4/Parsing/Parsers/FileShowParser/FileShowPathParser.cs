using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileShowParser;

public class FileShowPathParser : IParsingChain<FileShowModel.Builder>
{
    private IParsingChain<FileShowModel.Builder>? _next;
    public void AddNext(IParsingChain<FileShowModel.Builder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, FileShowModel.Builder builder)
    {
        if (command.Current[0] != '-')
        {
            builder.WithPath(command.Current);
            return new ParsingArgumentResult.Success();
        }

        if (_next is not null)
            return _next.Handle(command, builder);
        return new ParsingArgumentResult.Fail();
    }
}