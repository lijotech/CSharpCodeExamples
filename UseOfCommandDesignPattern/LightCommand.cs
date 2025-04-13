namespace UseOfCommandDesignPattern
{
    /// <summary>
    /// Concrete Command 
    /// </summary>
    public class LightCommand : ICommand
    {
        public readonly Light _light;
        public readonly Mode _mode;

        public LightCommand(Light light, Mode mode)
        {
            _light = light ?? throw new ArgumentNullException(nameof(light));
            _mode = mode;
        }

        public void Execute()
        {
            Console.WriteLine($"Executing action {_mode}");
            if (_mode.Equals(Mode.ON))
            {
                _light.TurnOn();
            }
            else
            {
                _light.TurnOff();
            }
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing action {_mode}");
            if (_mode.Equals(Mode.ON))
            {
                _light.TurnOff();
            }
            else
            {
                _light.TurnOn();
            }
        }
    }

    public enum Mode
    {
        ON,
        OFF
    }
}
