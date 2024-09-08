using ExtendFactoryPatternUsingDI.Enums;
using ExtendFactoryPatternUsingDI.Interface;

namespace ExtendFactoryPatternUsingDI.Services
{
    public class MaintanceServiceFactory
    {
        private readonly IEnumerable<IMaintanceService> _maintanceServices;
        public MaintanceServiceFactory(IEnumerable<IMaintanceService> maintanceServices)
        {
            _maintanceServices = maintanceServices;
        }
        public IMaintanceService GetMaintanceService(MaintanceMode mMode)
        {
            return _maintanceServices.FirstOrDefault(e => e.Mode == mMode)
                ?? throw new NotSupportedException();
        }
    }
}
