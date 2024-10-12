namespace ExtendBuilderDesignPattern.FacetedBuilder
{
    public class ComputerBuilderFacade
    {
        protected Computer Computer = new Computer();

        public Computer Build() => Computer;

        public ComputerConfigBuilder Config => new ComputerConfigBuilder(Computer);
        public ComputerLocationBuilder Location => new ComputerLocationBuilder(Computer);
    }
}
