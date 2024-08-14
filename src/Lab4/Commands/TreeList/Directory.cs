using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

public class Directory : IComponent
{
    public Directory(string name)
    {
        Name = name;
    }

    public IList<IComponent> Components { get; } = new List<IComponent>();
    public string Name { get; }

    public void Add(IComponent component)
    {
        Components.Add(component);
    }

    public void Accept(IVisit visitor, StringBuilder stringBuilder)
    {
        if (visitor is IVisitor<Directory> v)
        {
            v.Visit(this, stringBuilder);
        }
    }
}