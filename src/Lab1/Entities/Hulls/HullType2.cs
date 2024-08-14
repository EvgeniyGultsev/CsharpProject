namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public class HullType2 : IHull
{
    private double _healthPoints;

    public HullType2()
    {
        _healthPoints = 4.1;
    }

    public DamageResult GetDamage(double damage)
    {
        if (damage <= 1)
            damage = damage * 0.8;

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