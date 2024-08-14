namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

public class TreeListMaker : ITreeListMaker
{
    public void MakeTreeList(int currentDepth, int maxDepth, string currentWay, IComponent treeList)
    {
        if (currentDepth >= maxDepth) return;
        foreach (string filename in System.IO.Directory.GetFiles(currentWay))
        {
            treeList.Add(new FileComponent(filename));
        }

        foreach (string directory in System.IO.Directory.GetDirectories(currentWay))
        {
            var compositeDirectory = new Directory(directory);
            MakeTreeList(currentDepth + 1, maxDepth, directory, compositeDirectory);
            treeList.Add(compositeDirectory);
        }
    }
}