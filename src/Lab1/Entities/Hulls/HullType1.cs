namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public class HullType1 : IHull
{
    private double _healthPoints;

    public HullType1()
    {
        _healthPoints = 1.1;
    }

    public DamageResult GetDamage(double damage)
    {
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