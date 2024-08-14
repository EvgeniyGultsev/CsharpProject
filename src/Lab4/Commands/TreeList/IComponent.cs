using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

public interface IComponent
{
    public string Name { get; }
    public void Add(IComponent component);
    public void Accept(IVisit visitor, StringBuilder stringBuilder);
}