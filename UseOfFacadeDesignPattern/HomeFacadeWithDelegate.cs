namespace UseOfFacadeDesignPattern
{
    public class HomeFacadeWithDelegate
    {
        private Light _light;
        private MusicSystem _musicSystem;
        private AirConditioner _airConditioner;

        // Define delegates
        public delegate void CustomEntryAction();
        public delegate void CustomExitAction();

        // Events using delegates
        public event CustomEntryAction OnEntry;
        public event CustomExitAction OnExit;

        public HomeFacadeWithDelegate()
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

            // Invoke custom entry actions
            OnEntry?.Invoke();
        }

        public void HomeExitMode()
        {
            _light.Off();
            _musicSystem.StopMusic();

            // Invoke custom exit actions
            OnExit?.Invoke();
        }
    }

}
