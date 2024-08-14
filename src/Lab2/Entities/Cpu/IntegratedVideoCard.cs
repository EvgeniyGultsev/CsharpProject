namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public class IntegratedVideoCard : IIntegratedVideoCard
{
    public IntegratedVideoCard(int chipFrequency)
    {
        ChipFrequency = chipFrequency;
    }

    public int ChipFrequency { get; }
}