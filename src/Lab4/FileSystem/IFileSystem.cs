using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public ResultSystemOperation Delete(string path);
    public ResultSystemOperation Copy(string startPath, string endPath);
    public ResultSystemOperation Move(string startPath, string endPath);
    public ResultSystemOperation Rename(string startPath, string name);
    public string FileShow(string path);
    public IComponent TreeList(string path, int depth);
    public bool FileExists(string path);

    public bool DirectoryExists(string path);
}