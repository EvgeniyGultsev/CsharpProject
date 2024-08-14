namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

public interface IText
{
    public string Content { get; }
    public void SetModifier(IModifier modifier);
}