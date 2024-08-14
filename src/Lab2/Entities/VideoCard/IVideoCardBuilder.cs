namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public interface IVideoCardBuilder
{
    public IVideoCardBuilder WithLength(double length);
    public IVideoCardBuilder WithWidth(double width);
    public IVideoCardBuilder WithPciEVersion(string version);
    public IVideoCardBuilder WithChipFrequency(int frequency);
    public IVideoCardBuilder WithNeededPower(int power);
    public IVideoCardBuilder WithName(string name);
    public IDiscreteVideoCard Build();
}