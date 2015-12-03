using SmartHouse.Controls;
using SmartHouse.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartHouse
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DevicesList devices;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                devices = new DevicesList();

                devices.Add(new Lamp("MyLamp"));
                devices.Add(new Fridge("MyFridge"));
                devices.Add(new TV("MyTV"));
                devices.Add(new Shower("MyShower"));
                devices.Add(new Hoover("MyHoover"));
                //   Session["House"] = devices;
                

            }
            else
            {
                WrongName.Text = "";

                //devices = (DevicesList)Session["House"];
               
                    using (Stream stream = File.Open("E:/data.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        devices = (DevicesList)bin.Deserialize(stream);
                        stream.Close();
                    }
                
            }
            foreach (Device device in devices.Devices)
            {
                divDevices.Controls.Add(new DeviceControl(device.Name, devices));
            }
        }

        protected void AddDevice_Click(object sender, EventArgs e)
        {

            // devices = (DevicesList)Session["House"];

            
            if (!String.IsNullOrWhiteSpace(DeviceName.Text))
            {
                String deviceName = DeviceName.Text.Trim();

                if (!devices.Names.Contains(deviceName))
                {
                    Device device = null;
                    switch (((Button)sender).ID)
                    {
                        case ("AddLamp"):
                            device = new Lamp(deviceName);
                            break;
                        case ("AddFridge"):
                            device = new Fridge(deviceName);
                            break;
                        case ("AddTv"):
                            device = new TV(deviceName);
                            break;
                        case ("AddShower"):
                            device = new Shower(deviceName);
                            break;
                        case ("AddHoover"):
                            device = new Hoover(deviceName);
                            break;
                    }

                    devices.Add(device);
                    divDevices.Controls.Add(new DeviceControl(deviceName, devices));
                 }

                else
                {
                    WrongName.Text = "Device with this name already exists! Please, try again.";
                }
            }
            else
            {
                WrongName.Text = "Please, enter name for your device";

            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("E:/data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, devices);
                stream.Close();
            }
        }

       
        protected void SwitchOnAll_Click(object sender, EventArgs e)
        {
            
            // devices = (DevicesList)Session["House"];

            foreach (string key in devices.Names)
            {
                if(!((ISwitchable)devices[key]).State)
                ((DeviceControl)(divDevices.FindControl(key))).Switch_Click(sender, e);
            }
           
        }

        protected void SwitchOffAll_Click(object sender, EventArgs e)
        {
           
            // devices = (DevicesList)Session["House"];

            foreach (string key in devices.Names)
            {
                if (((ISwitchable)devices[key]).State)
                    ((DeviceControl)(divDevices.FindControl(key))).Switch_Click(sender, e);
            }
           
        }

        protected void DeleteAll_Click(object sender, EventArgs e)
        {
            
            // devices = (DevicesList)Session["House"];
            List<string> ld = new List<string>(devices.Names);
            foreach (string key in ld)
            {
                ((DeviceControl)(divDevices.FindControl(key))).Delete_Click(sender, e);
            }
            
        }

    }
    

}