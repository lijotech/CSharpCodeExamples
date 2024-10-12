namespace ExtendBuilderDesignPattern.RecursiveBuilder
{
    public class ComputerRAMBuilder<T> : ComputerGPUBuilder<ComputerRAMBuilder<T>> where T : ComputerRAMBuilder<T>
    {
        public T SetRAM(int ram)
        {
            computer.RAM = ram;
            return (T)this;
        }    
    }
}
