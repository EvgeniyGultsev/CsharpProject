using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public class Ram : IRam
{
    internal Ram(int storage, IReadOnlyList<int> acceptedFrequency, IReadOnlyList<int> acceptedVoltage, IReadOnlyList<XmpOrDocp> profiles, RamFormFactor ramFormFactor, DdrType ddrType, int power, string name)
    {
        Storage = storage;
        AcceptedFrequency = acceptedFrequency;
        AcceptedVoltage = acceptedVoltage;
        Profiles = profiles;
        RamFormFactor = ramFormFactor;
        DdrType = ddrType;
        Power = power;
        Name = name;
    }

    public int Storage { get; }
    public IReadOnlyList<int> AcceptedFrequency { get; }
    public IReadOnlyList<int> AcceptedVoltage { get; }
    public IReadOnlyList<XmpOrDocp> Profiles { get; }
    public RamFormFactor RamFormFactor { get; }
    public DdrType DdrType { get; }
    public int Power { get; }
    public string Name { get; }
    public void Direct(IRamBuilder builder)
    {
        builder.WithPower(Power);
        builder.WithName(Name);
        builder.WithProfiles(Profiles);
        builder.WithStorage(Storage);
        builder.WithAcceptedFrequency(AcceptedFrequency);
        builder.WithAcceptedVoltage(AcceptedVoltage);
        builder.WithRamFormFactor(RamFormFactor);
        builder.WithDdrType(DdrType);
    }
}