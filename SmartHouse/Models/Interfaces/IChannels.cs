using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Models.Interfaces
{
    interface IChannels
    {
        Channels CurrentChannel { get; set; }

        void PrevChannel();

        void NextChannel();

        string GetChannelsList();
    }
}
