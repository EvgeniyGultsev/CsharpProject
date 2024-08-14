namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public class Ssd : ISsd
{
    internal Ssd(ConnectionVersion connectionVersion, int capacity, int speed, int power, string name)
    {
        ConnectionVersion = connectionVersion;
        Capacity = capacity;
        Speed = speed;
        Power = power;
        Name = name;
    }

    public ConnectionVersion ConnectionVersion { get; }
    public int Capacity { get; }
    public int Speed { get; }
    public int Power { get; }
    public string Name { get; }
    public void Direct(ISsdBuilder builder)
    {
        builder.WithCapacity(Capacity);
        builder.WithName(Name);
        builder.WithPower(Power);
        builder.WithSpeed(Speed);
        builder.WithConnectionVersion(ConnectionVersion);
    }
}