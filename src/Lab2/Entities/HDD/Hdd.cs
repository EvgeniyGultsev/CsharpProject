namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;

public class Hdd : IHdd
{
    internal Hdd(string name, int capacity, int spindleSpeed, int power)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        Power = power;
        Name = name;
    }

    public int Capacity { get; }
    public int SpindleSpeed { get; }
    public int Power { get; }
    public string Name { get; }
    public void Direct(IHddBuilder builder)
    {
        builder.WithCapacity(Capacity);
        builder.WithSpindleSpeed(SpindleSpeed);
        builder.WithPower(Power);
        builder.WithName(Name);
    }
}