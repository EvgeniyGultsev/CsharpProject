using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;
using Directory = System.IO.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private readonly string _systemWay;
    public LocalFileSystem(string systemWay)
    {
        _systemWay = systemWay;
    }

    public ResultSystemOperation Delete(string path)
    {
        try
        {
            File.Delete(string.Concat(_systemWay, path));
            return new ResultSystemOperation.Success();
        }
        catch (Exception)
        {
            return new ResultSystemOperation.Fail();
        }
    }

    public ResultSystemOperation Copy(string startPath, string endPath)
    {
        try
        {
            File.Copy(string.Concat(_systemWay, startPath), string.Concat(_systemWay, endPath, Path.GetFileName(startPath)));
            return new ResultSystemOperation.Success();
        }
        catch (Exception)
        {
            return new ResultSystemOperation.Fail();
        }
    }

    public ResultSystemOperation Move(string startPath, string endPath)
    {
        try
        {
            File.Move(startPath, string.Concat(_systemWay, endPath,  Path.GetFileName(startPath)));
            return new ResultSystemOperation.Success();
        }
        catch (Exception)
        {
            return new ResultSystemOperation.Fail();
        }
    }

    public ResultSystemOperation Rename(string startPath, string name)
    {
        try
        {
            string newFileName = Path.Combine(
                Path.GetDirectoryName(
                    string.Concat(
                        _systemWay, startPath)) ?? string.Empty,
                string.Concat(
                    name, Path.GetExtension(
                        string.Concat(
                            _systemWay, startPath))));
            File.Move(startPath, newFileName);
            return new ResultSystemOperation.Success();
        }
        catch (Exception)
        {
            return new ResultSystemOperation.Fail();
        }
    }

    public string FileShow(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public IComponent TreeList(string path, int depth)
    {
        if (Directory.Exists(string.Concat(_systemWay, path)) is false)
            return new NullComponent();
        string fileStartComponent = string.Concat(_systemWay, path);
        IComponent start = new Commands.TreeList.Directory(fileStartComponent);
        new TreeListMaker().MakeTreeList(0, depth, fileStartComponent, start);
        return start;
    }

    public bool FileExists(string path)
    {
        return File.Exists(string.Concat(_systemWay, path));
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(string.Concat(_systemWay, path));
    }
}