using SmartHouse.Models.Classes;
using SmartHouse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    [Serializable]
    class Lamp : Device, ISwitchable, IBrightness
    {
        private bool state;
        private int brightness;
        private static readonly int MIN_BRIGHTNESS = 0;
        private static readonly int MAX_BRIGHTNESS = 10;

        public Lamp() : this(false,null) { }

        public Lamp(bool state, string name, int brightness = 5):base(name)
        { 
            this.state = state;
            Name = name;
            Brightness = brightness;
        }

        public Lamp(string name): this(false,name)
        {  }

        public bool State { get { return state; } }

        public int Brightness
        {
            get { return brightness; }
            set { if (value >= MIN_BRIGHTNESS && value <= MAX_BRIGHTNESS) brightness = value; }
        }

        public static int GetMinBrightness() { return MIN_BRIGHTNESS; }

        public static int GetMaxBrightness() { return MAX_BRIGHTNESS; }

        public void Switch() { state = !state; }

        public void IncreaseBrightness() { ChangeBrightness(Brightness + 1); }

        public void DecreaseBrightness() { ChangeBrightness(Brightness - 1); }

        public void ChangeBrightness(int brightness)
        {
            if (State)
                Brightness = brightness;
        }

        public override string ToString()
        {

            if (State) return "Lamp " + Name + " is on, " + " intensity = " + Brightness.ToString() + ";";
            else
                return "Lamp " + Name + " is off; ";
        }
        
    }
}
