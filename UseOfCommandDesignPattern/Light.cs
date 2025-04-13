namespace UseOfCommandDesignPattern
{
    /// <summary>
    /// Command Receiver 
    /// </summary>
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is OFF.");
        }
    }
}
