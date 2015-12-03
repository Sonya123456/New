using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models.Classes
{
    [Serializable]
    public class DevicesList
    {
        
        
        public List<string> Names
        {
            get;
            set;
        }

        public List<Device> Devices
        {
            get;
            set;
        }

        public DevicesList()
        {
            Devices = new List<Device>();
            Names = new List<string>();
        }

        public void Add(Device device)
        {
            Devices.Add(device);
            Names.Add(device.Name);
        }

        public void Remove(Device device)
        {
            Devices.Remove(device);
            Names.Remove(device.Name);
        }

        public void Remove(string id)
        {
            Remove(Find(id));
        }

        public Device Find(string id)
        {
            Device device = Devices.First(item => item.Name == id);
            return device;
        }

        public Device this[string index]
        {
            get { return Find(index); }
            set
            {
                Device device = Find(index);
                device = value;
            }
        }

       
    }
}