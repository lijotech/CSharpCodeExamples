using ExtendFactoryPatternUsingDI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendFactoryPatternUsingDI.Services
{
    public class LabelGenServiceFactory
    {
        private readonly VinLabelGenService _vinLabelGenService;
        private readonly IPrefixGenService _prefixGenService;

        public LabelGenServiceFactory(IPrefixGenService prefixGenService)
        {
            _prefixGenService = prefixGenService;
            _vinLabelGenService = new(_prefixGenService.GetPrefix());
        }

        public VinLabelGenService GetVinLabelGenService() => _vinLabelGenService;
    }
}
