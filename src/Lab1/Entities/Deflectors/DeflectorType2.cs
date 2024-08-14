namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorType2 : IDeflector
{
    private double _healthPoints;
    public DeflectorType2()
    {
        _healthPoints = 7;
    }

    public DamageResult GetDamage(double damage)
    {
        if (damage <= 1)
            damage = damage * 0.7;

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