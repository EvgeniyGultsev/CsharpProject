namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorType3 : IDeflector
{
    private double _healthPoints;
    public DeflectorType3()
    {
        _healthPoints = 20.1;
    }

    public DamageResult GetDamage(double damage)
    {
        if (damage <= 1)
            damage = damage * 0.5;

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