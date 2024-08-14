namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public interface ISsdBuilder
{
    public ISsdBuilder WithConnectionVersion(ConnectionVersion version);
    public ISsdBuilder WithCapacity(int capacity);
    public ISsdBuilder WithSpeed(int speed);
    public ISsdBuilder WithPower(int power);
    public ISsdBuilder WithName(string name);
    public ISsd Build();
}