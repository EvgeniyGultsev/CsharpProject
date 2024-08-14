namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public interface IDiscreteVideoCard : IComponent, IVideoCardBuilderDirector, IVideoCard
{
    public double Length { get; }
    public double Width { get; }
    public string PciEVersion { get; }
    public int NeededPower { get; }
}