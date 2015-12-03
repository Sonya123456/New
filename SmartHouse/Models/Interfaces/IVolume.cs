using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models.Interfaces
{
    public interface IVolume
    {
        byte Volume { get; set; }

        void IncreaseVolume();

        void DecreaseVolume();
    }
}