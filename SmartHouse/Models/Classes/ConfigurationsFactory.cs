using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    [Serializable]
    internal class ConfigurationsFactory
    {
        internal static TVConfigurations GetTVConfigurations()
        {
            return new TVConfigurations();
        }
    }
}
