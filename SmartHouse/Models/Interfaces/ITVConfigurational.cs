using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models.Interfaces
{
    interface ITVConfigurational
    {
        TVConfigurations Configurations
        {
            get;

        }

        void SetConfigurations(int intensity, int contrast, ImageModes imageMode, ColorModes colorMode );
    }
}
