using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models.Interfaces
{
    public interface IThermal
    {
        int Temperature 
        {
            get;
            set;
        }

        void IncreaseTemperature();

        void DecreaseTemperature();
    }
}