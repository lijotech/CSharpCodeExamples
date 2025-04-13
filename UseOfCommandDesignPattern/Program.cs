using UseOfCommandDesignPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Light livingRoomLight = new Light();

        RemoteControl remoteControl = new RemoteControl();

        // Execute commands
        remoteControl.Invoke(new LightCommand(livingRoomLight, Mode.ON));
        remoteControl.Invoke(new LightCommand(livingRoomLight, Mode.OFF));

        // Undo commands
        remoteControl.Undo();
        remoteControl.Undo();
        //show command history is empty
        remoteControl.Undo();
    }
}
