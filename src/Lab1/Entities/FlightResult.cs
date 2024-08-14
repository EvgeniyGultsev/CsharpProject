using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract record FlightResult
{
    private FlightResult()
    {
    }

    public sealed record NoEngineForHighDensitynebula : FlightResult;
    public sealed record LostShip : FlightResult;
    public sealed record DestroyedShip : FlightResult;
    public sealed record CrewDeath : FlightResult;
    public sealed record Success(double UsedTime, IReadOnlyList<IFuel> UsedFuel) : FlightResult;
}