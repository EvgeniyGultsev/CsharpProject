using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public interface IRamBuilder
{
    public IRamBuilder WithStorage(int storage);
    public IRamBuilder WithAcceptedFrequency(IEnumerable<int> frequency);
    public IRamBuilder WithAcceptedVoltage(IEnumerable<int> voltage);
    public IRamBuilder WithProfiles(IEnumerable<XmpOrDocp> profiles);
    public IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor);
    public IRamBuilder WithDdrType(DdrType ddrType);
    public IRamBuilder WithPower(int power);
    public IRamBuilder WithName(string name);
    public IRam Build();
}