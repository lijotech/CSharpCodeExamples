namespace ExtendBuilderDesignPattern.FacetedBuilder
{
    public class ComputerConfigBuilder: ComputerBuilderFacade
    {
        public ComputerConfigBuilder(Computer computer)
        {
            Computer = computer;  
        }

        public ComputerConfigBuilder SetCPU(string cpu)
        {
            Computer.CPU = cpu;
            return this;
        }

        public ComputerConfigBuilder SetGPU(string gpu)
        {
            Computer.GPU = gpu;
            return this;
        }

        public ComputerConfigBuilder SetRAM(int ram)
        {
            Computer.RAM = ram;
            return this;
        }

        public ComputerConfigBuilder SetStorage(int storage)
        {
            Computer.Storage = storage;
            return this;
        }
    }
}
