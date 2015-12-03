using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models.Interfaces
{
    interface IAbsorbtion
    { 
         int AbsorbtionPower
        {
            get;
            set;
        }

        void IncreaseAbsorbtionPower();
        void DecreaseAbsorbtionPower();
    }
}
