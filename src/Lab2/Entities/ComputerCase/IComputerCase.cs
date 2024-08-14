using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public interface IComputerCase : IComponent, IComputerCaseBuilderDirector
{
    public int MaxVideoCardLength { get; }
    public int MaxVideoCardWidth { get; }
    public IReadOnlyList<FormFactor> AcceptableFormFactors { get; }
    public int Height { get; }
    public int Length { get; }
    public int Width { get; }
}