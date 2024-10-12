namespace ExtendBuilderDesignPattern
{
    public class ComputerGPUBuilder<T> : ComputerCPUBuilder<ComputerGPUBuilder<T>> where T : ComputerGPUBuilder<T>
    {
        public T SetGPU(string gpu)
        {
            computer.GPU = gpu;
            return (T)this;
        }
    }
}
