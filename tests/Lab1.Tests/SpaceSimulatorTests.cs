using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceSimulatorTests
{
    public static IEnumerable<object[]> Test1 =>
        new List<object[]>
        {
            new object[] { new Shuttle(), new FlightResult.NoEngineForHighDensitynebula() },
            new object[] { new Avgur(new DeflectorType3()), new FlightResult.LostShip() },
        };

    public static IEnumerable<object[]> Test2 =>
        new List<object[]>
        {
            new object[] { new Vaklas(new DeflectorType1()), new FlightResult.CrewDeath() },
            new object[] { new Vaklas(new PhotonDeflector(new DeflectorType1())), new FlightResult.Success(0, new List<IFuel>()) },
        };

    public static IEnumerable<object[]> Test3 =>
        new List<object[]>
        {
            new object[] { new Vaklas(new PhotonDeflector(new DeflectorType1())), new FlightResult.DestroyedShip() },
            new object[] { new Avgur(new DeflectorType3()), new FlightResult.Success(0, new List<IFuel>()) },
            new object[] { new Meredian(new DeflectorType2()), new FlightResult.Success(0, new List<IFuel>()) },
        };

    [Theory]
    [MemberData(nameof(Test1))]
    public void HighDensityNebulaWithShuttleAndAvgurShipsGoThroughTheWayShuttleDontJumpAvgurIsLost(ISpaceShip ship, FlightResult expectedFlightResult)
    {
        // Arrange
        const int distance = 400;
        var surroundings = new List<ISurrounding> { new HighDensityNebula(new List<Antimatter>(), distance) };
        var way = new Way(surroundings);

        // Act
        FlightResult flightResult = way.TryToFly(ship);

        // Assert
        Assert.Equal(expectedFlightResult, flightResult);
    }

    [Theory]
    [MemberData(nameof(Test2))]
    public void AntimatterFlashVaklasVaklasGoThroughTheWayNoPhotonCrewDeathYesPhotonSuccess(ISpaceShip ship, FlightResult expectedFlightResult)
    {
        // Arrange
        const int distance = 200;
        var way = new Way(new List<ISurrounding> { new HighDensityNebula(new List<Antimatter> { new Antimatter() }, distance) });

        // Act
        FlightResult flightResult = way.TryToFly(ship);

        // Assert
        Assert.Equal(expectedFlightResult.GetType(), flightResult.GetType());
    }

    [Theory]
    [MemberData(nameof(Test3))]
    public void VaklasAvgurMeredianInNitrineWithWhaleGoThroughTheWayVaklasDestroyedOtherSuccess(ISpaceShip ship, FlightResult expectedFlightResult)
    {
        // Arrange
        const int distance = 100;
        var way = new Way(new List<ISurrounding> { new NitrineNebula(new List<Whale> { new Whale() }, distance) });

        // Act
        FlightResult flightResult = way.TryToFly(ship);

        // Assert
        Assert.Equal(expectedFlightResult.GetType(), flightResult.GetType());
    }

    [Fact]
    public void ShuttleVaklasGoThroughSpaceChooseBestChooseShuttle()
    {
        // Arrange
        IChooseEffectiveShip chooseEffectiveShip = new ChooseEffectiveMoneyShip();
        ISpaceShip shuttle = new Shuttle();
        ISpaceShip vaklas = new Vaklas(new DeflectorType1());
        ISpaceShip? theChosenOne;
        IExchange exchange = new Exchange();
        var ships = new List<ISpaceShip> { shuttle, vaklas };
        var way = new Way(new List<ISurrounding> { new Space(new List<ISpaceObstacle>(), 100) });

        // Act
        theChosenOne = chooseEffectiveShip.FindTheBestShipForTheWay(way, ships, exchange);

        // Arrange
        Assert.Equal(shuttle, theChosenOne);
    }

    [Fact]
    public void AvgurAndStellaMiddleHighDensityNebulaGoThroughWayStellaChoosen()
    {
        // Arrange
        IChooseEffectiveShip chooseEffectiveShip = new ChooseEffectiveMoneyShip();
        ISpaceShip avgur = new Avgur(new DeflectorType3());
        ISpaceShip stella = new Stella(new DeflectorType1());
        var ships = new List<ISpaceShip> { avgur, stella };
        ISpaceShip? theChoosenOne;
        IExchange exchange = new Exchange();
        var way = new Way(new List<ISurrounding> { new HighDensityNebula(new List<Antimatter>(), 400) });

        // Act
        theChoosenOne = chooseEffectiveShip.FindTheBestShipForTheWay(way, ships, exchange);

        // Assert
        Assert.Equal(stella, theChoosenOne);
    }

    [Fact]
    public void ShuttleAndVaklasInNitrineGoThroughWayVaklasChosen()
    {
        // Arrange
        IChooseEffectiveShip chooseEffectiveShip = new ChooseEffectiveMoneyShip();
        ISpaceShip shuttle = new Shuttle();
        ISpaceShip vaklas = new Vaklas(new DeflectorType1());
        ISpaceShip? theChosenOne;
        IExchange exchange = new Exchange();
        var ships = new List<ISpaceShip> { shuttle, vaklas };
        var way = new Way(new List<ISurrounding> { new NitrineNebula(new List<Whale>(), 100) });

        // Act
        theChosenOne = chooseEffectiveShip.FindTheBestShipForTheWay(way, ships, exchange);

        // Assert
        Assert.Equal(vaklas, theChosenOne);
    }

    [Fact]
    public void AllShipsGoThroughHighDensityNebulaAndNitrineNebulaNoShipCanGoThrough()
    {
        // Arrange
        IChooseEffectiveShip chooseEffectiveShip = new ChooseEffectiveMoneyShip();
        ISpaceShip shuttle = new Shuttle();
        ISpaceShip vaklas = new Vaklas(new DeflectorType1());
        ISpaceShip avgur = new Avgur(new PhotonDeflector(new DeflectorType3()));
        ISpaceShip stella = new Stella(new PhotonDeflector(new DeflectorType1()));
        ISpaceShip meredian = new Meredian(new PhotonDeflector(new DeflectorType2()));
        IExchange exchange = new Exchange();
        var ships = new List<ISpaceShip> { shuttle, vaklas, avgur, stella, meredian };
        var way = new Way(new List<ISurrounding> { new HighDensityNebula(new List<Antimatter>(), 400), new NitrineNebula(new List<Whale> { new Whale() }, 100) });
        ISpaceShip? theChosenOne;

        // Act
        theChosenOne = chooseEffectiveShip.FindTheBestShipForTheWay(way, ships, exchange);

        // Assert
        Assert.Null(theChosenOne);
    }
}