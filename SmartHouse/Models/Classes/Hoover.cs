using SmartHouse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models.Classes
{
    [Serializable]
    public class Hoover:Device,ISwitchable,IAbsorbtion,ICleaningModal
    {
        private bool state;
        private int absorbtionPower;
        private CleaningModes mode;
        private static readonly int MIN_POWER = 0;
        private static readonly int MAX_POWER = 20;

        public Hoover() : this(false,null) { }

        public Hoover(bool state, string name, int absorbtionPower = 5):base(name)
        {
            this.state = state;
            Name = name;
            AbsorbtionPower = absorbtionPower;
        }

        public Hoover(string name): this(false,name)
        { }

        public bool State { get { return state; } }

        public int AbsorbtionPower
        {
            get { return absorbtionPower; }
            set { if (value >= MIN_POWER && value <= MAX_POWER) absorbtionPower = value; }
        }

        public CleaningModes Mode
        {
            get
            {
                 return mode;
            }

            set
            {
                if (State)
                {
                    mode = value;
                    if (value == CleaningModes.Turbo)
                        AbsorbtionPower = MAX_POWER;
                }
            }
        }

        public void Switch() { state = !state; }

        public void IncreaseAbsorbtionPower()
        {
            AbsorbtionPower++;
        }
        public void DecreaseAbsorbtionPower()
        {
            AbsorbtionPower--;
        }

        public void ChangeMode()
        {
            if ((int)Mode + 1 == Enum.GetValues(typeof(CleaningModes)).Length)
                Mode = (CleaningModes)Enum.GetValues(typeof(CleaningModes)).GetValue(0);
            else
                Mode++;
        }
    }
}