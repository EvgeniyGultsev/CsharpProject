using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;
using Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ConfiguratorTests
{
    private readonly Repository<IComputerCase> _computerCase = new Repository<IComputerCase>();
    private readonly Repository<ICpu> _cpu = new Repository<ICpu>();
    private readonly Repository<IBios> _bios = new Repository<IBios>();
    private readonly Repository<ICooler> _cooler = new Repository<ICooler>();
    private readonly Repository<IHdd> _hdd = new Repository<IHdd>();
    private readonly Repository<IRam> _ram = new Repository<IRam>();
    private readonly Repository<IPowerSupply> _powerSupply = new Repository<IPowerSupply>();
    private readonly Repository<ISsd> _ssd = new Repository<ISsd>();
    private readonly Repository<IDiscreteVideoCard> _videoCard = new Repository<IDiscreteVideoCard>();
    private readonly Repository<IDiscreteWiFiModule> _wifi = new Repository<IDiscreteWiFiModule>();
    private readonly Repository<IMotherBoard> _motherBoard = new Repository<IMotherBoard>();

    private readonly IList<IComputerValidator> _validator = new List<IComputerValidator>
    {
        new ComputerCaseNotNullValidator(),
        new CoolerFitsCaseValidator(),
        new CoolerFitsCpuValidator(),
        new CoolerFitsMotherBoardValidator(),
        new CoolerNotNullValidator(),
        new CpuFitsBiosValidator(),
        new CpuFitsMotherBoardValidator(),
        new CpuNotNullValidator(),
        new EnoughPciPortsValidator(),
        new EnoughRamSlotsValidator(),
        new EnoughSataPortsValidator(),
        new MotherBoardFitsComputerCaseValidator(),
        new MotherBoardNotNullValidator(),
        new PowerSupplyFitsComputerValidator(),
        new PowerSupplyNotNullValidator(),
        new RamNotEmptyValidator(),
        new RamFitsMotherBoardValidator(),
        new RomNotEmptyValidator(),
        new VideoCardFitsCaseValidator(),
        new VideoCardNotNullValidator(),
        new WifiFitsMotherBoardValidator(),
    };
    public ConfiguratorTests()
    {
        IComputerCaseBuilder caseBuilder = new ComputerCaseBuilder();
        ICpuBuilder cpuBuilder = new CpuBuilder();
        IBiosBuilder biosBuilder = new BiosBuilder();
        ICoolerBuilder coolerBuilder = new CoolerBuilder();
        IHddBuilder hddBuilder = new HddBuilder();
        IPowerSupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        IRamBuilder ramBuilder = new RamBuilder();
        ISsdBuilder ssdBuilder = new SsdBuilder();
        IVideoCardBuilder videoCardBuilder = new VideoCardBuilder();
        IWiFiModuleBuilder wifiBuilder = new WifiModuleBuilder();
        IMotherBoardBuilder motherBoardBuider = new MotherBoardBuilder();

        // CpuBuild
        cpuBuilder.WithName("Intel Core i5-10400F");
        cpuBuilder.WithSocket("LGA 1200");
        cpuBuilder.WithPower(77);
        cpuBuilder.WithTdp(65);
        cpuBuilder.WithCoreFrequency(2900);
        cpuBuilder.WithCoreNumber(6);
        cpuBuilder.WithVideoCore(null);
        cpuBuilder.WithAcceptableRamFrequency(new List<int> { 2300, 2666 });
        _cpu.Add(cpuBuilder.Build());
        cpuBuilder.WithName("AMD Ryzen 5 3600");
        cpuBuilder.WithSocket("AM 4");
        cpuBuilder.WithPower(87);
        cpuBuilder.WithTdp(65);
        cpuBuilder.WithCoreFrequency(3600);
        cpuBuilder.WithCoreNumber(6);
        cpuBuilder.WithVideoCore(null);
        cpuBuilder.WithAcceptableRamFrequency(new List<int> { 2666, 3200 });
        _cpu.Add(cpuBuilder.Build());

        // Bios Build
        biosBuilder.WithType("Bios");
        biosBuilder.WithName("Bios1");
        biosBuilder.WithVersion("1.0");
        biosBuilder.WithSupportedCpus(new List<ICpu> { _cpu.GetComponent("Intel Core i5-10400F") });
        _bios.Add(biosBuilder.Build());
        biosBuilder.WithType("UEFI");
        biosBuilder.WithName("UEFI1");
        biosBuilder.WithVersion("1.1");
        biosBuilder.WithSupportedCpus(new List<ICpu> { _cpu.GetComponent("AMD Ryzen 5 3600") });
        _bios.Add(biosBuilder.Build());

        // Computer Case
        caseBuilder.WithName("MyBlock");
        caseBuilder.WithHeight(200);
        caseBuilder.WithLength(200);
        caseBuilder.WithWidth(200);
        caseBuilder.WithFormFactors(new List<FormFactor> { FormFactor.Atx, FormFactor.EAtx, FormFactor.MicroAtx });
        caseBuilder.WithMaxVideoCardLength(200);
        caseBuilder.WithMaxVideoCardWidth(200);
        _computerCase.Add(caseBuilder.Build());

        // Cooler
        coolerBuilder.WithName("Intel Laminar RS1");
        coolerBuilder.WithHeight(15);
        coolerBuilder.WithTdp(60);
        coolerBuilder.WithSockets(new List<string> { "LGA 1200" });
        _cooler.Add(coolerBuilder.Build());
        coolerBuilder.WithName("Cooler Master I30");
        coolerBuilder.WithHeight(20);
        coolerBuilder.WithTdp(70);
        coolerBuilder.WithSockets(new List<string> { "AM 4" });
        _cooler.Add(coolerBuilder.Build());

        // HDD
        hddBuilder.WithName("Seagate");
        hddBuilder.WithPower(70);
        hddBuilder.WithCapacity(30);
        hddBuilder.WithSpindleSpeed(5000);
        _hdd.Add(hddBuilder.Build());

        // Power Block
        powerSupplyBuilder.WithPower(600);
        powerSupplyBuilder.WithName("AeroCool VX PLUS");
        _powerSupply.Add(powerSupplyBuilder.Build());
        powerSupplyBuilder.WithPower(350); // add coomment test
        powerSupplyBuilder.WithName("KCASBomb");
        _powerSupply.Add(powerSupplyBuilder.Build());

        // Ram
        ramBuilder.WithPower(30);
        ramBuilder.WithName("AMD Radeon R7 Performance Series");
        ramBuilder.WithProfiles(new[] { new XmpOrDocp(new List<int> { 18, 18, 36, 54 }, 1, 2666, "DOCP-3200") });
        ramBuilder.WithStorage(8);
        ramBuilder.WithAcceptedFrequency(new[] { 2666 });
        ramBuilder.WithAcceptedVoltage(new[] { 1 });
        ramBuilder.WithRamFormFactor(RamFormFactor.Dimm);
        ramBuilder.WithDdrType(DdrType.Ddr4);
        _ram.Add(ramBuilder.Build());
        ramBuilder.WithPower(30);
        ramBuilder.WithName("Kingston ValueRAM");
        ramBuilder.WithProfiles(new[] { new XmpOrDocp(new List<int> { 18, 18, 36, 54 }, 1, 2666, "Xmp-3200") });
        ramBuilder.WithStorage(8);
        ramBuilder.WithAcceptedFrequency(new[] { 2666 });
        ramBuilder.WithAcceptedVoltage(new[] { 1 });
        ramBuilder.WithRamFormFactor(RamFormFactor.Dimm);
        ramBuilder.WithDdrType(DdrType.Ddr4);
        _ram.Add(ramBuilder.Build());

        // ssd
        ssdBuilder.WithPower(50);
        ssdBuilder.WithName("SataSsd");
        ssdBuilder.WithCapacity(1024);
        ssdBuilder.WithConnectionVersion(ConnectionVersion.Sata);
        ssdBuilder.WithSpeed(600);
        _ssd.Add(ssdBuilder.Build());
        ssdBuilder.WithPower(40);
        ssdBuilder.WithName("PciESsd");
        ssdBuilder.WithCapacity(1024);
        ssdBuilder.WithConnectionVersion(ConnectionVersion.PciE);
        ssdBuilder.WithSpeed(600);
        _ssd.Add(ssdBuilder.Build());

        // VideoCard
        videoCardBuilder.WithName("RTX3060");
        videoCardBuilder.WithLength(70);
        videoCardBuilder.WithWidth(50);
        videoCardBuilder.WithChipFrequency(1320);
        videoCardBuilder.WithNeededPower(150);
        videoCardBuilder.WithPciEVersion("PciE1");
        _videoCard.Add(videoCardBuilder.Build());

        // Wifi
        wifiBuilder.WithPower(25);
        wifiBuilder.WithPciEVersion("PciE1");
        wifiBuilder.WithName("Digma DWA-AC13002E");
        wifiBuilder.WithBluetooth(false);
        wifiBuilder.WithVersion("DWA-AC13002E");
        _wifi.Add(wifiBuilder.Build());

        // MotherBoard
        motherBoardBuider.WithName("Biostar H510MHP 2.0");
        motherBoardBuider.WithBios(_bios.GetComponent("Bios1"));
        motherBoardBuider.WithDdrType(DdrType.Ddr4);
        motherBoardBuider.WithChipset(new Chipset(new List<int> { 2666 }, new[] { new XmpOrDocp(new List<int> { 18, 18, 36, 54 }, 1, 2666, "DOCP-3200") }));
        motherBoardBuider.WithSocket("LGA 1200");
        motherBoardBuider.WithFormFactor(FormFactor.Atx);
        motherBoardBuider.WithRamNumber(4);
        motherBoardBuider.WithSataPorts(4);
        motherBoardBuider.WithPciELines(4);
        motherBoardBuider.WithIntegratedWifiModule(null);
        _motherBoard.Add(motherBoardBuider.Build());
        motherBoardBuider.WithName("GIGABYTE B450 GAMING X");
        motherBoardBuider.WithBios(_bios.GetComponent("UEFI1"));
        motherBoardBuider.WithDdrType(DdrType.Ddr4);
        motherBoardBuider.WithChipset(new Chipset(new List<int> { 2666 }, new[] { new XmpOrDocp(new List<int> { 18, 18, 36, 54 }, 1, 2666, "DOCP-3200") }));
        motherBoardBuider.WithSocket("AM 4");
        motherBoardBuider.WithFormFactor(FormFactor.Atx);
        motherBoardBuider.WithRamNumber(4);
        motherBoardBuider.WithSataPorts(4);
        motherBoardBuider.WithPciELines(4);
        motherBoardBuider.WithIntegratedWifiModule(null);
        _motherBoard.Add(motherBoardBuider.Build());
    }

    [Fact]
    public void SuccessfulComputerBuilder()
    {
        var computerBuilder = new ComputerBuilder(_validator);
        computerBuilder.WithMotherBoard(_motherBoard.GetComponent("GIGABYTE B450 GAMING X"));
        computerBuilder.WithCpu(_cpu.GetComponent("AMD Ryzen 5 3600"));
        computerBuilder.WithCooler(_cooler.GetComponent("Cooler Master I30"));
        computerBuilder.WithRam(new List<IRam>() { _ram.GetComponent("Kingston ValueRAM") });
        computerBuilder.WithVideoCard(_videoCard.GetComponent("RTX3060"));
        computerBuilder.WithSsd(new List<ISsd> { _ssd.GetComponent("SataSsd") });
        computerBuilder.WithHdd(new List<IHdd> { _hdd.GetComponent("Seagate") });
        computerBuilder.WithComputerCase(_computerCase.GetComponent("MyBlock"));
        computerBuilder.WithPowerSupply(_powerSupply.GetComponent("AeroCool VX PLUS"));
        computerBuilder.WithWifi(null);
        Assert.Equal(typeof(ConfiguratorResult.Success), computerBuilder.Build().GetType());
    }

    [Fact]
    public void SuccessComment()
    {
        var computerBuilder = new ComputerBuilder(_validator);
        computerBuilder.WithMotherBoard(_motherBoard.GetComponent("GIGABYTE B450 GAMING X"));
        computerBuilder.WithCpu(_cpu.GetComponent("AMD Ryzen 5 3600"));
        computerBuilder.WithCooler(_cooler.GetComponent("Cooler Master I30"));
        computerBuilder.WithRam(new List<IRam>() { _ram.GetComponent("Kingston ValueRAM") });
        computerBuilder.WithVideoCard(_videoCard.GetComponent("RTX3060"));
        computerBuilder.WithSsd(new List<ISsd> { _ssd.GetComponent("SataSsd") });
        computerBuilder.WithHdd(new List<IHdd> { _hdd.GetComponent("Seagate") });
        computerBuilder.WithComputerCase(_computerCase.GetComponent("MyBlock"));
        computerBuilder.WithPowerSupply(_powerSupply.GetComponent("KCASBomb"));
        computerBuilder.WithWifi(null);
        Assert.Equal(typeof(ConfiguratorResult.SuccessWithWarnings), computerBuilder.Build().GetType());
    }

    [Fact]
    public void SuccessNoGuarantee()
    {
        var computerBuilder = new ComputerBuilder(_validator);
        computerBuilder.WithMotherBoard(_motherBoard.GetComponent("Biostar H510MHP 2.0"));
        computerBuilder.WithCpu(_cpu.GetComponent("Intel Core i5-10400F"));
        computerBuilder.WithCooler(_cooler.GetComponent("Intel Laminar RS1"));
        computerBuilder.WithRam(new List<IRam>() { _ram.GetComponent("Kingston ValueRAM") });
        computerBuilder.WithVideoCard(_videoCard.GetComponent("RTX3060"));
        computerBuilder.WithSsd(new List<ISsd> { _ssd.GetComponent("SataSsd") });
        computerBuilder.WithHdd(new List<IHdd> { _hdd.GetComponent("Seagate") });
        computerBuilder.WithComputerCase(_computerCase.GetComponent("MyBlock"));
        computerBuilder.WithPowerSupply(_powerSupply.GetComponent("AeroCool VX PLUS"));
        computerBuilder.WithWifi(null);
        Assert.Equal(typeof(ConfiguratorResult.SuccessWithWarnings), computerBuilder.Build().GetType());
    }

    [Fact]
    public void RejectedPcCpuMotherboard()
    {
        var computerBuilder = new ComputerBuilder(_validator);
        computerBuilder.WithMotherBoard(_motherBoard.GetComponent("GIGABYTE B450 GAMING X"));
        computerBuilder.WithCpu(_cpu.GetComponent("Intel Core i5-10400F"));
        computerBuilder.WithCooler(_cooler.GetComponent("Cooler Master I30"));
        computerBuilder.WithRam(new List<IRam>() { _ram.GetComponent("Kingston ValueRAM") });
        computerBuilder.WithVideoCard(_videoCard.GetComponent("RTX3060"));
        computerBuilder.WithSsd(new List<ISsd> { _ssd.GetComponent("SataSsd") });
        computerBuilder.WithHdd(new List<IHdd> { _hdd.GetComponent("Seagate") });
        computerBuilder.WithComputerCase(_computerCase.GetComponent("MyBlock"));
        computerBuilder.WithPowerSupply(_powerSupply.GetComponent("AeroCool VX PLUS"));
        computerBuilder.WithWifi(null);
        Assert.Equal(typeof(ConfiguratorResult.Failure), computerBuilder.Build().GetType());
    }

    [Fact]
    public void RejectedNoMotherBoard()
    {
        var computerBuilder = new ComputerBuilder(_validator);
        computerBuilder.WithMotherBoard(null);
        computerBuilder.WithCpu(_cpu.GetComponent("Intel Core i5-10400F"));
        computerBuilder.WithCooler(_cooler.GetComponent("Intel Laminar RS1"));
        computerBuilder.WithRam(new List<IRam>() { _ram.GetComponent("Kingston ValueRAM") });
        computerBuilder.WithVideoCard(_videoCard.GetComponent("RTX3060"));
        computerBuilder.WithSsd(new List<ISsd> { _ssd.GetComponent("SataSsd") });
        computerBuilder.WithHdd(new List<IHdd> { _hdd.GetComponent("Seagate") });
        computerBuilder.WithComputerCase(_computerCase.GetComponent("MyBlock"));
        computerBuilder.WithPowerSupply(_powerSupply.GetComponent("AeroCool VX PLUS"));
        computerBuilder.WithWifi(null);
        Assert.Equal(typeof(ConfiguratorResult.Failure), computerBuilder.Build().GetType());
    }
}