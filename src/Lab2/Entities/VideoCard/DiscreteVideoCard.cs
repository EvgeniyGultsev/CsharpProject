namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public class DiscreteVideoCard : IDiscreteVideoCard
{
    internal DiscreteVideoCard(double length, double width, string pciEVersion, int chipFrequency, int neededPower, string name)
    {
        Length = length;
        Width = width;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        NeededPower = neededPower;
        Name = name;
    }

    public double Length { get; }
    public double Width { get; }
    public string PciEVersion { get; }
    public int ChipFrequency { get; }
    public int NeededPower { get; }
    public string Name { get; }
    public void Direct(IVideoCardBuilder builder)
    {
        builder.WithName(Name);
        builder.WithLength(Length);
        builder.WithWidth(Width);
        builder.WithChipFrequency(ChipFrequency);
        builder.WithNeededPower(NeededPower);
        builder.WithPciEVersion(PciEVersion);
    }
}