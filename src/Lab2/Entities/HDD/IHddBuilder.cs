namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;

public interface IHddBuilder
{
    public IHddBuilder WithName(string name);
    public IHddBuilder WithCapacity(int capacity);
    public IHddBuilder WithSpindleSpeed(int speed);
    public IHddBuilder WithPower(int power);
    public IHdd Build();
}