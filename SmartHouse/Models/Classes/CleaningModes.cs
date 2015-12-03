using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models.Classes
{
    [Serializable]
    public enum CleaningModes
    {
        Spot,
        Zig_zag,
        Cell_by_Cell,
        Stain,
        Turbo
    }
}