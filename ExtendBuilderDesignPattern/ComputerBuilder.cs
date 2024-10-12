namespace ExtendBuilderDesignPattern
{
    public abstract class ComputerBuilder
    {
        protected Computer computer;

        public ComputerBuilder()
        {
            computer = new Computer();
        }

        public Computer Build() => computer;
    }
}
