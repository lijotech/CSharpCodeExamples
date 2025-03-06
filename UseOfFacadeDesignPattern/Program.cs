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
