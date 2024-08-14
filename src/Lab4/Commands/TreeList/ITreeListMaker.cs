namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;

public interface ITreeListMaker
{
    public void MakeTreeList(int currentDepth, int maxDepth, string currentWay, IComponent treeList);
}