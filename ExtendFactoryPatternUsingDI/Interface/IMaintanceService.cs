using ExtendFactoryPatternUsingDI.Enums;

namespace ExtendFactoryPatternUsingDI.Interface
{
    public interface IMaintanceService
    {
        string Perform(string message);

        MaintanceMode Mode { get; }
    }
}
