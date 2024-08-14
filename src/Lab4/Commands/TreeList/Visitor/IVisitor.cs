using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;

public interface IVisitor<T> : IVisit
    where T : IComponent
{
    void Visit(T component, StringBuilder stringBuilder);
}