using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.TreeListParser;

public class TreeListDepthParser : IParsingChain<TreeListModel.Builder>
{
    private IParsingChain<TreeListModel.Builder>? _next;
    public void AddNext(IParsingChain<TreeListModel.Builder> link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);
    }

    public ParsingArgumentResult Handle(IEnumerator<string> command, TreeListModel.Builder builder)
    {
        if (command.Current == "-d")
        {
            if (command.MoveNext())
            {
                bool parsed = int.TryParse(command.Current, out int depth);
                if (parsed)
                    builder.WithDepth(depth);
                else
                    return new ParsingArgumentResult.Fail();

                return new ParsingArgumentResult.Success();
            }
        }

        if (_next is not null)
            return _next.Handle(command, builder);
        return new ParsingArgumentResult.Fail();
    }
}