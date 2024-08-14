namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

public class Text : IText
{
    private string _content;

    public Text(string content)
    {
        _content = content;
    }

    public string Content => _content;

    public void SetModifier(IModifier modifier)
    {
        modifier.Modify(_content);
    }
}