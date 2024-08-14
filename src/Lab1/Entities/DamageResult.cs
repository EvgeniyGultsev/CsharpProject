namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract record DamageResult
{
    private DamageResult()
    {
    }

    public sealed record NotBlockedDamage(double Damage) : DamageResult;
    public sealed record BlockedAllDamage : DamageResult;
}