using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private int _videoCardLength;
    private int _videoCardWidth;
    private IEnumerable<FormFactor>? _formFactors;
    private int _length;
    private int _width;
    private int _height;
    private string? _name;

    public IComputerCaseBuilder WithMaxVideoCardLength(int length)
    {
        _videoCardLength = length;
        return this;
    }

    public IComputerCaseBuilder WithMaxVideoCardWidth(int width)
    {
        _videoCardWidth = width;
        return this;
    }

    public IComputerCaseBuilder WithFormFactors(IEnumerable<FormFactor> formFactors)
    {
        _formFactors = formFactors;
        return this;
    }

    public IComputerCaseBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public IComputerCaseBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public IComputerCaseBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public IComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IComputerCase Build()
    {
        if (_length <= 0) throw new ArgumentException();
        if (_width <= 0) throw new ArgumentException();
        if (_height <= 0) throw new ArgumentException();
        if (_videoCardWidth <= 0) throw new ArgumentException();
        if (_videoCardLength <= 0) throw new ArgumentException();
        return new ComputerCase(
                            _name ?? throw new ArgumentNullException(),
                            _videoCardLength,
                            _videoCardWidth,
                            (_formFactors ?? throw new ArgumentNullException()).ToList(),
                            _height,
                            _length,
                            _width);
    }
}