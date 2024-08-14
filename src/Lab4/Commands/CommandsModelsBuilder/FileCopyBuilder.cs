using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;

public class FileCopyBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyBuilder WithSourcePath(string path)
    {
        if (_sourcePath is null)
        {
            _sourcePath = path;
            return this;
        }

        return WithDestinationPath(path);
    }

    public FileCopyBuilder WithDestinationPath(string path)
    {
        _destinationPath = path;
        return this;
    }

    public FileCopyModel Build()
    {
        return new FileCopyModel(
            _sourcePath ?? throw new ArgumentNullException(),
            _destinationPath ?? throw new ArgumentNullException());
    }
}