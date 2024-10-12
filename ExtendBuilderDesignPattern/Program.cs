namespace ExtendBuilderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var computer = ComputerBuilderDirector.NewComputer
                            .SetCPU("Intel i9")
                            .SetGPU("NVIDIA RTX 3080")
                            .SetRAM(32)
                            .SetStorage(1000)
                            .Build();

            Console.WriteLine(computer);
        }
    }
}