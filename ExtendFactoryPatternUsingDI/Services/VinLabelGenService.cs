namespace ExtendFactoryPatternUsingDI.Services
{
    public class VinLabelGenService
    {
        public string Prefix { get; }
        public VinLabelGenService(string prefix)
        {
            Prefix = prefix;
        }
        public string Generate() => $"{Prefix}{Guid.NewGuid()}";
    }
}