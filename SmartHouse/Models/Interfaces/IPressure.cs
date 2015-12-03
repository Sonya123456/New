using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models.Interfaces
{
    interface IPressure
    { 
        int Pressure
        {
            get;
            set;
        }

        void IncreasePressure();

        void DecreasePressure();
    }
}
