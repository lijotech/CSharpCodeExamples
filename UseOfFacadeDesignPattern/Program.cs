using UseOfFacadeDesignPattern;

class Program
{
    static void Main(string[] args)
    {
        HomeFacade homeFacade = new HomeFacade();

        // Entering home
        homeFacade.HomeEntryMode();

        // Exiting home
        homeFacade.HomeExitMode();

        Console.WriteLine();

        HomeFacadeWithDelegate homeFacadeWithDelegate = new HomeFacadeWithDelegate();

        // Subscribe to entry event with a custom action
        homeFacadeWithDelegate.OnEntry += () => Console.WriteLine("Custom action: Welcome home!");

        // Subscribe to exit event with a custom action
        homeFacadeWithDelegate.OnExit += () => Console.WriteLine("Custom action: Goodbye!");

        // Entering home
        homeFacadeWithDelegate.HomeEntryMode();

        // Exiting home
        homeFacadeWithDelegate.HomeExitMode();
    }
}

public class Light
{
    public void On() => Console.WriteLine("Lights are ON");
    public void Off() => Console.WriteLine("Lights are OFF");
}

public class MusicSystem
{
    public void PlayMusic() => Console.WriteLine("Playing music");
    public void StopMusic() => Console.WriteLine("Music stopped");
}

public class AirConditioner
{
    public void SetTemperature(int temperature) => Console.WriteLine($"Temperature set to {temperature} degrees");
}
