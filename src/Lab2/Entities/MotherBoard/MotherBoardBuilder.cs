using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private string? _socket;
    private int _pciELines;
    private int _sataPorts;
    private Chipset? _chipset;
    private DdrType? _ddrType;
    private int _ramNumber;
    private FormFactor? _formFactor;
    private IBios? _bios;
    private string? _name;
    private IIntegratedWifiModule? _wifiModule;

    public IMotherBoardBuilder WithIntegratedWifiModule(IIntegratedWifiModule? wifiModule)
    {
        _wifiModule = wifiModule;
        return this;
    }

    public IMotherBoardBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherBoardBuilder WithPciELines(int lines)
    {
        _pciELines = lines;
        return this;
    }

    public IMotherBoardBuilder WithSataPorts(int ports)
    {
        _sataPorts = ports;
        return this;
    }

    public IMotherBoardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherBoardBuilder WithDdrType(DdrType ddrType)
    {
        _ddrType = ddrType;
        return this;
    }

    public IMotherBoardBuilder WithRamNumber(int ramNumber)
    {
        _ramNumber = ramNumber;
        return this;
    }

    public IMotherBoardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoard Build()
    {
        if (_pciELines <= 0) throw new ArgumentException();
        if (_sataPorts <= 0) throw new ArgumentException();
        if (_ramNumber <= 0) throw new ArgumentException();
        return new MotherBoard(
            _socket ?? throw new ArgumentNullException(),
            _pciELines,
            _sataPorts,
            _chipset ?? throw new ArgumentNullException(),
            _ddrType ?? throw new ArgumentNullException(),
            _ramNumber,
            _formFactor ?? throw new ArgumentNullException(),
            _bios ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException(),
            _wifiModule);
    }
}