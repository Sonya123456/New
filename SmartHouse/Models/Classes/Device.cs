using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models.Classes
{
    [Serializable]
    public abstract class Device
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Device(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "Device " + Name;
        }
    }
}