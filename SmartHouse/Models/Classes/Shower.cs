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
    class Shower : Device, ISwitchable, IThermal, IPressure
    {
        private bool state;
        private int temperature;
        private int pressure;
        private static readonly int MAX_TEMP = 50;
        private static readonly int MIN_TEMP = 15;
        private static readonly int MAX_PRESSURE = 100;
        private static readonly int MIN_PRESSURE = 0;


        public Shower():this(false,null) { }

        public Shower(bool state, string name, int temperature=38, int pressure=60):base(name)
        {
            this.state = state;
            Name = name;
            Temperature = temperature;
            Pressure = pressure;
        }

        public Shower(string name): this (false, name)
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

        public int Pressure
        {
            get { return pressure; }
            set { if (value >= MIN_PRESSURE && value <= MAX_PRESSURE) pressure = value; }
        }

        public void Switch() { state = !state; }

        public void IncreaseTemperature () { if (State) Temperature++; }

        public void DecreaseTemperature() { if (State) Temperature--; }

        public void IncreasePressure() { if (State) Pressure++; }

        public void DecreasePressure() { if (State) Pressure--; }

        public static int GetMinTemp() { return MIN_TEMP; }

        public static int GetMaxTemp() { return MAX_TEMP; }

        public static int GetMinPressure() { return MIN_PRESSURE; }

        public static int GetMaxPressure() { return MAX_PRESSURE; }

        public override string ToString()
        {
            if (State)
                return "Shower " + Name + " is on, temperature is " + Temperature.ToString() + " Celsius degrees, pressure is " + Pressure.ToString()+";";
            else
                return "Shower " + Name + " is off;";
        }
    }
}
