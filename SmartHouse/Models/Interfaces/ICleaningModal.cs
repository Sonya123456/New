using SmartHouse.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models.Interfaces
{
    interface ICleaningModal
    {
        CleaningModes Mode { get; set; }

        void ChangeMode();
    }
}
