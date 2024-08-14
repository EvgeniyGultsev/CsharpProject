using System.Linq;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;

public class Visitor : IVisitor<Directory>, IVisitor<FileComponent>
{
    private readonly Signs _signs;
    private int _depth;

    public Visitor(Signs signs)
    {
        _signs = signs;
        _depth = 0;
    }

    public void Visit(Directory component, StringBuilder stringBuilder)
    {
        stringBuilder.Append(string.Concat(Enumerable.Range(0, _depth).Select(_ => _signs.Indent)));
        stringBuilder.Append(_signs.Directory);
        stringBuilder.Append(component.Name);
        stringBuilder.Append('\n');
        _depth++;
        foreach (IComponent components in component.Components)
        {
            components.Accept(this, stringBuilder);
        }

        _depth--;
    }

    public void Visit(FileComponent component, StringBuilder stringBuilder)
    {
        _depth++;
        stringBuilder.Append(string.Concat(Enumerable.Range(0, _depth).Select(_ => _signs.Indent)));
        stringBuilder.Append(_signs.File);
        stringBuilder.Append(component.Name);
        stringBuilder.Append('\n');
        _depth--;
    }
}