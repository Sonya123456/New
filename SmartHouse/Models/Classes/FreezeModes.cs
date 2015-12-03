using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    [Serializable]
    public enum FreezeModes:byte
    { 
        SuperFreeze,
        SuperColling,
        Vacation,
        Custom
    }
}
