namespace UseOfFacadeDesignPattern
{
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
            Console.WriteLine("**Entering home**");
            _light.On();
            _musicSystem.PlayMusic();
            _airConditioner.SetTemperature(22);
        }

        public void HomeExitMode()
        {
            Console.WriteLine("**Exiting home**");
            _light.Off();
            _musicSystem.StopMusic();
        }
    }

}
