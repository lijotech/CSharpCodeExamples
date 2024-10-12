using ExtendBuilderDesignPattern.FacetedBuilder;
using ExtendBuilderDesignPattern.RecursiveBuilder;

namespace ExtendBuilderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===Recurisive Builder Example===");
            var computer = ComputerBuilderDirector.NewComputer
                            .SetCPU("Intel i9")
                            .SetGPU("NVIDIA RTX 3080")
                            .SetRAM(32)
                            .SetStorage(1000)
                            .InCity("Honkong")
                            .AtAddress("1234 ABC Town")
                            .Build();

            Console.WriteLine(computer);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("===Faceted Builder Example===");
            var computerfaceted = new ComputerBuilderFacade()
                                    .Config
                                        .SetCPU ("Intel x22")
                                        .SetGPU("NVIDIA 3200")
                                        .SetRAM(32)
                                        .SetStorage(1200)
                                    .Location
                                        .InCity ("Berlin")
                                        .AtAddress("1234 DEH Town")
                                    .Build ();

            Console.WriteLine(computerfaceted);
        }
    }
}