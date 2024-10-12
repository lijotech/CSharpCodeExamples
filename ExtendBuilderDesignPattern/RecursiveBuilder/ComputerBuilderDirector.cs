namespace ExtendBuilderDesignPattern.RecursiveBuilder
{
    public class ComputerBuilderDirector : ComputerStorageBuilder<ComputerBuilderDirector>
    {
        public static ComputerBuilderDirector NewComputer => new ComputerBuilderDirector();
    }
}
