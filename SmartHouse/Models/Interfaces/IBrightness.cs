using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models.Interfaces
{
    interface IBrightness
    {
        int Brightness { get; set; }

        void IncreaseBrightness();

        void DecreaseBrightness();
    }
}
