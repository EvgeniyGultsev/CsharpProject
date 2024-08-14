using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.TreeGoToParser;

public class TreeGoToPathParser : IParsingChain<TreeGoToModel.Builder>
{
    private IParsingChain<TreeGoToModel.Builder>? _next;
    public void AddNext(IParsingChain<TreeGoToModel.Builder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, TreeGoToModel.Builder builder)
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