namespace Game.Energy
{
    public enum EnergyType
    {
        Warmth,
        Void
    }
    public interface IEnergyProvider
    {
        EnergyType EnergyType { get; }
        (EnergyType energyType, float energyValue) GetEnergy();
    }
}