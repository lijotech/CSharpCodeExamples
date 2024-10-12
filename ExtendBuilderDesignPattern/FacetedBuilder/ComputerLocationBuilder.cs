namespace ExtendBuilderDesignPattern.FacetedBuilder
{
    public class ComputerLocationBuilder: ComputerBuilderFacade
    {
        public ComputerLocationBuilder(Computer computer)
        {
            Computer = computer;
        }

        public ComputerLocationBuilder InCity(string city)
        {
            Computer.City = city;
            return this;
        }

        public ComputerLocationBuilder AtAddress(string address)
        {
            Computer.Address = address;
            return this;
        }
    }
}
