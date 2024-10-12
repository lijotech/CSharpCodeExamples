namespace ExtendBuilderDesignPattern.RecursiveBuilder
{
    public class ComputerCPUBuilder<T> : ComputerBuilder where T : ComputerCPUBuilder<T>
    {
        public T SetCPU(string cpu)
        {
            computer.CPU = cpu;
            return (T)this;
        }
    }
}
