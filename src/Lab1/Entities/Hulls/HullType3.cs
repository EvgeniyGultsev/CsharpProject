namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public class HullType3 : IHull
{
    private double _healthPoints;

    public HullType3()
    {
        _healthPoints = 10.1;
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
        else
        {
            DamageResult temporary = new DamageResult.NotBlockedDamage(damage - _healthPoints);
            _healthPoints = 0;
            return temporary;
        }
    }
}