using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public interface IComputerCaseBuilder
{
    public IComputerCaseBuilder WithMaxVideoCardLength(int length);
    public IComputerCaseBuilder WithMaxVideoCardWidth(int width);
    public IComputerCaseBuilder WithFormFactors(IEnumerable<FormFactor> formFactors);
    public IComputerCaseBuilder WithLength(int length);
    public IComputerCaseBuilder WithWidth(int width);
    public IComputerCaseBuilder WithHeight(int height);
    public IComputerCaseBuilder WithName(string name);
    public IComputerCase Build();
}