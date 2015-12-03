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
    class Fridge : Device, ISwitchable, IThermal, IFreezeModal
    {
        private bool state;
        private FreezeModes mode;
        private int temperature;
        private static readonly int MAX_TEMP = 15;
        private static readonly int MIN_TEMP = -24;

        public Fridge():this(false,null)
        { }

        public Fridge(bool state,string name, FreezeModes mode=FreezeModes.Custom, int temperature = 4):base(name)
        {
            this.state = state;
            Name = name;
            Mode = mode;
            Temperature = temperature;
        }

        public Fridge(string name):this(false, name)
        { }

        public bool State 
        {
            get { return state; }
        }

     

        public int Temperature
        {
            get { return temperature; }
            set { if (value >= MIN_TEMP && value <= MAX_TEMP) temperature = value; }
        }

        public static int GetMinTemp () { return MIN_TEMP; }

        public static int GetMaxTemp () { return MAX_TEMP;}

        public FreezeModes Mode
        {
            get { return mode; }
            set
            { if (State)
                {
                    switch (value)
                    {
                        case FreezeModes.SuperFreeze:
                            Temperature = MIN_TEMP;
                            break;
                        case FreezeModes.SuperColling:
                            Temperature = 2;
                            break;
                        case FreezeModes.Vacation:
                            Temperature = MAX_TEMP;
                            break;
                    }
                    mode = value;
                }
            }
        }

        

        public void ChangeTemperature(int temperature)
        {
            if (State)
            {
                if (temperature != MAX_TEMP && temperature != MIN_TEMP)
                {
                    Temperature = temperature;
                    Mode = FreezeModes.Custom;
                }
            }
        }

        public void IncreaseTemperature()
        {
            ChangeTemperature(Temperature + 1);
        }

        public void DecreaseTemperature()
        {
            ChangeTemperature(Temperature - 1);
        }

        public void ChangeMode()
        {

            if ((int)Mode + 1 == Enum.GetValues(typeof(FreezeModes)).Length)
                Mode = (FreezeModes)Enum.GetValues(typeof(FreezeModes)).GetValue(0);
            else
                Mode++;

        }

        public void Switch()
        {
            state = !state;
        }

        public override string ToString()
        {

            if (State)
            {

                return "Fridge " + Name + " is on, current temperature: " + Temperature + ", current mode: " + Mode + ";";
            }
            else
            {
                return "Fridge " + Name + " is off";
            }

        }
       
    }
}
