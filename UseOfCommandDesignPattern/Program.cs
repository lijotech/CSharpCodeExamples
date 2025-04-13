using UseOfCommandDesignPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Light livingRoomLight = new Light();

        ICommand lightCommand = new LightCommand(livingRoomLight,Mode.ON);    

        RemoteControl remoteControl = new RemoteControl();

        // Execute commands
        remoteControl.Invoke(lightCommand);
        remoteControl.Invoke(new LightCommand(livingRoomLight, Mode.OFF));

        // Undo commands
        remoteControl.Undo();
        remoteControl.Undo();
    }
}
