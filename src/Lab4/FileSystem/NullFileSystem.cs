using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class NullFileSystem : IFileSystem
{
    public ResultSystemOperation Delete(string path)
    {
        return new ResultSystemOperation.Fail();
    }

    public ResultSystemOperation Copy(string startPath, string endPath)
    {
        return new ResultSystemOperation.Fail();
    }

    public ResultSystemOperation Move(string startPath, string endPath)
    {
        return new ResultSystemOperation.Fail();
    }

    public ResultSystemOperation Rename(string startPath, string name)
    {
        return new ResultSystemOperation.Fail();
    }

    public string FileShow(string path)
    {
        return string.Empty;
    }

    public IComponent TreeList(string path, int depth)
    {
        return new NullComponent();
    }

    public bool FileExists(string path)
    {
        return false;
    }

    public bool DirectoryExists(string path)
    {
        return false;
    }
}