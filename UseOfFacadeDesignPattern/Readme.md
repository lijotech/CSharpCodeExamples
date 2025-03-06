##Facade design pattern

The Facade design pattern is a structural pattern that provides a simplified interface to a complex system of classes, libraries, or frameworks. It hides the complexities of the system and provides a client with an easy-to-use interface.

Key Components of the Facade Pattern
Facade: The class that simplifies the interface to the complex system.

Subsystem classes: Classes that implement the functionalities.

Use Cases
The Facade pattern is particularly useful when:

You want to provide a simple interface to a complex subsystem.

You want to decouple your code from the subsystem, making it more modular and easier to maintain.

You want to layer your application, with a facade layer that provides interfaces to the business logic or service layer.

Real-World Example in C#
Imagine you are developing a Home Automation System. The system consists of various subsystems like Lights, Music System, and Air Conditioner. Instead of the client interacting with each subsystem directly, you provide a facade that simplifies these interactions.

Here's how you can implement it in C#:

Subsystem Classes
```
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

```
Facade Class

```
public class HomeFacade
{
    private Light _light;
    private MusicSystem _musicSystem;
    private AirConditioner _airConditioner;

    public HomeFacade()
    {
        _light = new Light();
        _musicSystem = new MusicSystem();
        _airConditioner = new AirConditioner();
    }

    public void HomeEntryMode()
    {
        _light.On();
        _musicSystem.PlayMusic();
        _airConditioner.SetTemperature(22);
    }

    public void HomeExitMode()
    {
        _light.Off();
        _musicSystem.StopMusic();
    }
}

```
## Usage
```
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

```


Explanation
Subsystem Classes: Light, MusicSystem, and AirConditioner are subsystems with their own functionalities.

Facade Class: HomeFacade is the facade class that provides a simplified interface to control all the subsystems.

HomeEntryMode(): Turns on the lights, starts playing music, and sets the air conditioner to 22 degrees.

HomeExitMode(): Turns off the lights and stops playing music.

Usage: In the Main method, we create an instance of HomeFacade and use its methods to control the subsystems without interacting with them directly.

By using the Facade pattern, we encapsulate the complexities of the subsystems and provide a simple and easy-to-use interface to the client. This enhances code readability, reduces dependencies, and improves maintenance.

## Facade pattern using delegates

We can enhance the Facade pattern using delegates in C#. Delegates are useful for defining callback methods or events that you want the Facade to handle. This adds a layer of flexibility to the pattern by allowing the client to provide custom behavior without modifying the facade.

Let's extend the Home Automation System example to include delegates:


Explanation
Subsystem Classes: Remain unchanged with Light, MusicSystem, and AirConditioner.

Facade Class with Delegates:

Delegates and Events: CustomEntryAction and CustomExitAction are delegates that define custom actions. The OnEntry and OnExit events are used to subscribe to these actions.

HomeEntryMode() and HomeExitMode(): These methods now invoke custom actions through the OnEntry and OnExit events.

Usage with Delegates:

Subscribing to Events: In the Main method, custom actions are subscribed to the OnEntry and OnExit events. These actions will be executed when the respective methods are called.

Using delegates in the Facade pattern allows for additional customization and flexibility without changing the Facade class itself. The client can define and attach custom behaviors, enhancing the functionality as needed.