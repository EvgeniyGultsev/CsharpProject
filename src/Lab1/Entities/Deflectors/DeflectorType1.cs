namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorType1 : IDeflector
{
    private double _healthPoints;
    public DeflectorType1()
    {
        _healthPoints = 3;
    }

    public DamageResult GetDamage(double damage)
    {
        if (_healthPoints > damage)
        {
            _healthPoints -= damage;
            return new DamageResult.BlockedAllDamage();
        }

        var temporary = new DamageResult.NotBlockedDamage(damage - _healthPoints);
        _healthPoints = 0;
        return temporary;
    }
}