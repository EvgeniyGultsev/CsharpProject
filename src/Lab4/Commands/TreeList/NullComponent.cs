using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

public class NullComponent : IComponent
{
    public string Name { get; } = string.Empty;

    public void Add(IComponent component)
    {
    }

    public void Accept(IVisit visitor, StringBuilder stringBuilder)
    {
    }
}