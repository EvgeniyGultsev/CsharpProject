using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModelsBuilder;

public class FileRenameBuilder
{
    private string? _sourcePath;
    private string? _name;

    public FileRenameBuilder WithSourcePath(string path)
    {
        if (_sourcePath is null)
        {
            _sourcePath = path;
            return this;
        }

        return WithName(path);
    }

    public FileRenameBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public FileRenameModel Build()
    {
        return new FileRenameModel(
            _sourcePath ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException());
    }
}