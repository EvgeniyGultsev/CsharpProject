using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

public class FileComponent : IComponent
{
    public FileComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Add(IComponent component)
    {
    }

    public void Accept(IVisit visitor, StringBuilder stringBuilder)
    {
        if (visitor is IVisitor<FileComponent> v)
        {
            v.Visit(this, stringBuilder);
        }
    }
}