using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public class ComputerCase : IComputerCase
{
    internal ComputerCase(string name, int maxVideoCardLength, int maxVideoCardWidth, IReadOnlyList<FormFactor> acceptableFormFactors, int height, int length, int width)
    {
        Name = name;
        MaxVideoCardLength = maxVideoCardLength;
        MaxVideoCardWidth = maxVideoCardWidth;
        AcceptableFormFactors = acceptableFormFactors;
        Height = height;
        Length = length;
        Width = width;
    }

    public string Name { get; }
    public int MaxVideoCardLength { get; }
    public int MaxVideoCardWidth { get; }
    public IReadOnlyList<FormFactor> AcceptableFormFactors { get; }
    public int Height { get; }
    public int Length { get; }
    public int Width { get; }
    public void Direct(IComputerCaseBuilder builder)
    {
        builder.WithHeight(Height);
        builder.WithLength(Length);
        builder.WithWidth(Width);
        builder.WithFormFactors(AcceptableFormFactors);
        builder.WithName(Name);
        builder.WithMaxVideoCardLength(MaxVideoCardLength);
        builder.WithMaxVideoCardWidth(MaxVideoCardWidth);
    }
}