namespace ExtendFactoryPatternUsingDI.Services
{
    public class OilService
    {
        private bool _isVehicleSwitchedOff = false;
        public void InitialCheck()
        {
            //perform initial check before oil change
            _isVehicleSwitchedOff = true;
        }
        public string DrainOil(string performedBy)
        {
            if (!_isVehicleSwitchedOff)
                throw new InvalidOperationException("Vehicle is not ready");
            return $"Draining oil performed by: {performedBy}";
        }

        public string AddOil(string performedBy)
        {
            if (!_isVehicleSwitchedOff)
                throw new InvalidOperationException("Vehicle is not ready");
            return $"Adding new oil performed by: {performedBy}";
        }
    }
}
