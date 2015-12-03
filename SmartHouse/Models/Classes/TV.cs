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
    class TV : Device, ISwitchable, IVolume, IChannels, ITVConfigurational
    {
        private bool state;
        private byte volume;
        private Channels currentChannel;
        private TVConfigurations configurations;
        private static readonly int MAX_VOLUME = 100;
        private static readonly int MIN_VOLUME = 0;



        public TV() : this(false, null) { }

        public TV (bool state, string name, byte volume=55, Channels currentChannel=Channels.News):base(name)
        {
            
            configurations = ConfigurationsFactory.GetTVConfigurations();
            this.state = state;
            this.currentChannel = currentChannel;
            Name = name;
            Volume = volume;

        }

        public TV(string name):this (false, name)
        { }

        public bool State
        { get { return state; } }

       
        public byte Volume 
        {
            get { return volume; }
            set { if(value >= MIN_VOLUME && value <= MAX_VOLUME) volume=value;}
        }

        public Channels CurrentChannel
        {
            get { return currentChannel; }
            set {
                if (State)
                {
                    int length = Enum.GetNames(typeof(Channels)).Length;
                    if ((int)value >= 0 && (int)value <= length)
                        currentChannel = (Channels)value;
                }
                    
                }
        }

        public TVConfigurations Configurations
        {
            get { return configurations; }
            
        }
       
        public void Switch()
        { state = !state; }

        public void IncreaseVolume() { if(State) Volume++; }

        public void DecreaseVolume() { if (State) Volume--; }

        public void NextChannel()
        {
           
            if ((byte)currentChannel + 1 == Enum.GetNames(typeof(Channels)).Length) 
             CurrentChannel = (Channels)Enum.GetValues(typeof(Channels)).GetValue(0);
            else CurrentChannel++;
        }

        public void PrevChannel()
        {
            
            if ((byte)currentChannel == 0)
            {
                int length = Enum.GetNames(typeof(Channels)).Length;
                CurrentChannel = (Channels)Enum.GetValues(typeof(Channels)).GetValue(length - 1);
            }
            else CurrentChannel--;
        }

        public void ChangeChannel(byte value)
        {
            
               CurrentChannel = (Channels)value;
            
        }

        public string GetChannelsList()
        {
            Array channels = Enum.GetValues(typeof(Channels));
            string channelsList = null;
            foreach (Channels channel in channels)
                channelsList += ((int)channel + 1).ToString() + "." + channel.ToString() + System.Environment.NewLine;
            return channelsList;
        }

        public void SetConfigurations(int intensity=0, int contrast=0, ImageModes imageMode=0, ColorModes colorMode=0 )
        {
            if (State)
            {
                if (intensity != 0) configurations.Intensity = intensity;
                if (contrast != 0) configurations.Contrast = contrast;
                if (imageMode != 0) configurations.ImageMode = imageMode;
                if (colorMode != 0) configurations.ColorMode = colorMode;
            }
        }
       

        public override string ToString()
        {
           
            if (State)
            {
               
                return "TV " + Name  + "is on" + ", current channel: " + currentChannel.ToString() + ", current volume: " + volume.ToString() + 
                  "\n" + "current image mode: " + configurations.ImageMode + "\n"+"current color mode: "+configurations.ColorMode+
                  "\n" + "current intensity:"+configurations.Intensity+"\n"+ "current contrast: "+configurations.Contrast+";";
            }
            else
            {
                return "TV " + Name + " is off";
            }
             
        }
        
    }

    
}
