using SmartHouse.Models.Classes;
using SmartHouse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace SmartHouse.Controls
{
    public class DeviceControl:Panel
    {

        private DevicesList divecesDictionary;


        private Button deleteButton;
        private Button switchButton;
        private Label nameLabel;
        private string id;

        private ChangePanel changeBrightnessPanel;
        private ChangePanel changeTemperaturePanel;
        private ChangePanel changePressurePanel;
        private ChangePanel changeVolumePanel;
        private ChangePanel changeChannelsPanel;
        private ChangePanel changeIntensityPanel;
        private ChangePanel changeContrastPanel;
        private ChangePanel changeAbsorbtionPowerPanel;
        private ModePanel freezeModePanel;
        private ModePanel imageModePanel;
        private ModePanel colorModePanel;
        private ModePanel cleaningModePanel;
        private Panel tvConfigurations;
        private Label channelsList;
        private Button channelsButton;
        private Button settingsButton;



        public DeviceControl (string id, DevicesList devicesList)
        {
            
            this.id = id;
            this.ID = id;
            this.divecesDictionary = devicesList;
            
            
            deleteButton = new Button();
            deleteButton.ID = "deleteBtn-" + id;
            deleteButton.CssClass = "delete";
            
            deleteButton.Click += new EventHandler(Delete_Click);

            nameLabel = new Label();
            nameLabel.Text = devicesList[id].GetType().Name + " " + id;
            nameLabel.CssClass = "devname";


            CssClass = "device";
            Controls.Add(nameLabel);
            Controls.Add(deleteButton);

            Initialize();


        }

        private void Initialize()
        {
            Device device = divecesDictionary[id];
            if (device is ISwitchable)
            {
                CssClass = ((ISwitchable)device).State ? "device" : "switchOffdevice";

                switchButton = new Button();
                switchButton.ID = "switchBtn-" + id;
                
                switchButton.CssClass = "switch";
                switchButton.Click += new EventHandler(Switch_Click);

                Controls.Add(switchButton); 

            }

            if (device is IBrightness)
            {
                changeBrightnessPanel = new ChangePanel(id,"Brightness", ((IBrightness)device).Brightness.ToString(), ((ISwitchable)device).State);
                changeBrightnessPanel.IncreaseButton.Click += new EventHandler(this.increaseBrightnessButton_Click);
                changeBrightnessPanel.DecreaseButton.Click += new EventHandler(this.decreaseBrightnessButton_Click);
                Controls.Add(changeBrightnessPanel);
            }

            if (device is IThermal)
            {
                changeTemperaturePanel = new ChangePanel(id, "Temperature", ((IThermal)device).Temperature.ToString(), ((ISwitchable)device).State);
                changeTemperaturePanel.IncreaseButton.Click += new EventHandler(this.increaseTemperatureButton_Click);
                changeTemperaturePanel.DecreaseButton.Click += new EventHandler(this.decreaseTemperatureButton_Click);
                Controls.Add(changeTemperaturePanel);
            }

            if (device is IPressure)
            {
                changePressurePanel = new ChangePanel(id, "Pressure", ((IPressure)device).Pressure.ToString(), ((ISwitchable)device).State);
                changePressurePanel.IncreaseButton.Click += new EventHandler(this.increasePressureButton_Click);
                changePressurePanel.DecreaseButton.Click += new EventHandler(this.decreasePressureButton_Click);
                Controls.Add(changePressurePanel);
            }

            if (device is IVolume)
            {
                changeVolumePanel = new ChangePanel(id, "Volume", ((IVolume)device).Volume.ToString(), ((ISwitchable)device).State);
                changeVolumePanel.IncreaseButton.Click += new EventHandler(this.increaseVolumeButton_Click);
                changeVolumePanel.DecreaseButton.Click += new EventHandler(this.decreaseVolumeButton_Click);
                Controls.Add(changeVolumePanel);
            }

            if (device is IChannels)
            {
                changeChannelsPanel = new ChangePanel(id, "Channels", ((IChannels)device).CurrentChannel.ToString(), ((ISwitchable)device).State);
                changeChannelsPanel.IncreaseButton.Click += new EventHandler(this.increaseChannelButton_Click);
                changeChannelsPanel.DecreaseButton.Click += new EventHandler(this.decreaseChannelButton_Click);
                Controls.Add(changeChannelsPanel);

                channelsButton = new Button();
                channelsButton.ID = "channelsButton-" + device.Name;
                channelsButton.Style.Add("right", "70px");
                channelsButton.Text = "Channels";
                channelsButton.CssClass = ((ISwitchable)device).State ? "setButton" : "buttonOff";
                channelsButton.Click += new EventHandler(this.channelsButton_Click);
                Controls.Add(channelsButton);

                
            }

            if (device is IFreezeModal)
            {
                freezeModePanel = new ModePanel(id, "Mode", ((IFreezeModal)divecesDictionary[id]).Mode.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                freezeModePanel.ChangeModeButton.Click += new EventHandler(this.changeFreezeModeButton_Click);
                Controls.Add(freezeModePanel);
               
            }

            if (device is ITVConfigurational)
            {
                tvConfigurations = new Panel();
                tvConfigurations.Visible = false;

                imageModePanel = new ModePanel(id, "Image Mode", ((ITVConfigurational)divecesDictionary[id]).Configurations.ImageMode.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                imageModePanel.ChangeModeButton.Click += new EventHandler(this.changeImageModeButton_Click);
                tvConfigurations.Controls.Add(imageModePanel);

                changeIntensityPanel = new ChangePanel(id,"Intensity",((ITVConfigurational)divecesDictionary[id]).Configurations.Intensity.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                changeIntensityPanel.IncreaseButton.Click += new EventHandler(this.increaseIntensityButton_Click);
                changeIntensityPanel.DecreaseButton.Click += new EventHandler(this.decreaseIntensityButton_Click);
                tvConfigurations.Controls.Add(changeIntensityPanel);

                colorModePanel = new ModePanel(id, "Color Mode", ((ITVConfigurational)divecesDictionary[id]).Configurations.ColorMode.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                colorModePanel.ChangeModeButton.Click += new EventHandler(this.changeColorModeButton_Click);
                tvConfigurations.Controls.Add(colorModePanel);

                changeContrastPanel = new ChangePanel(id, "Contrast", ((ITVConfigurational)divecesDictionary[id]).Configurations.Contrast.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                changeContrastPanel.IncreaseButton.Click += new EventHandler(this.increaseContrastButton_Click);
                changeContrastPanel.DecreaseButton.Click += new EventHandler(this.decreaseContrastButton_Click);
                tvConfigurations.Controls.Add(changeContrastPanel);

                Controls.Add(tvConfigurations);

                settingsButton = new Button();
                settingsButton.ID = "settingsButton-" + device.Name;
                settingsButton.Text = "Settings";
                settingsButton.CssClass = (((ISwitchable)divecesDictionary[id]).State) ? "setButton" : "buttonOff";
                settingsButton.Click += new EventHandler(this.settingsButton_Click);

                Controls.Add(settingsButton);

                channelsList = new Label();
                channelsList.ID = "channelsLabel-" + id;
                channelsList.Text = ((IChannels)divecesDictionary[id]).GetChannelsList();
                channelsList.CssClass = "feature";
                channelsList.Visible = false;
                Controls.Add(channelsList);
            }

            if (device is ICleaningModal)
            {
                cleaningModePanel = new ModePanel(id, "Mode", ((ICleaningModal)divecesDictionary[id]).Mode.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                cleaningModePanel.ChangeModeButton.Click += new EventHandler(this.ChangeModeButton_Click);
                Controls.Add(cleaningModePanel);
            }
            if (device is IAbsorbtion)
            {
                changeAbsorbtionPowerPanel = new ChangePanel(id, "Absorbtion Power", ((IAbsorbtion)divecesDictionary[id]).AbsorbtionPower.ToString(), ((ISwitchable)divecesDictionary[id]).State);
                changeAbsorbtionPowerPanel.IncreaseButton.Click += new EventHandler(this.IncreaseAbsobtionPowerButton_Click);
                changeAbsorbtionPowerPanel.DecreaseButton.Click += new EventHandler(this.DecreaseAbsobtionPowerButton_Click);
                Controls.Add(changeAbsorbtionPowerPanel);
            }
        }

        private void IncreaseAbsobtionPowerButton_Click(object sender, EventArgs e)
        {
            ((IAbsorbtion)divecesDictionary[id]).IncreaseAbsorbtionPower();
            changeAbsorbtionPowerPanel.ValueLabel.Text = ((IAbsorbtion)divecesDictionary[id]).AbsorbtionPower.ToString();
            
        }

        private void DecreaseAbsobtionPowerButton_Click(object sender, EventArgs e)
        {
            ((IAbsorbtion)divecesDictionary[id]).DecreaseAbsorbtionPower();
            changeAbsorbtionPowerPanel.ValueLabel.Text = ((IAbsorbtion)divecesDictionary[id]).AbsorbtionPower.ToString();
        }

        private void ChangeModeButton_Click(object sender, EventArgs e)
        {
            ((ICleaningModal)divecesDictionary[id]).ChangeMode();
            cleaningModePanel.ValueLabel.Text = ((ICleaningModal)divecesDictionary[id]).Mode.ToString();
            if(((ICleaningModal)divecesDictionary[id]).Mode == CleaningModes.Turbo)
                changeAbsorbtionPowerPanel.ValueLabel.Text = ((IAbsorbtion)divecesDictionary[id]).AbsorbtionPower.ToString();
        }

        private void decreaseContrastButton_Click(object sender, EventArgs e)
        {
            ((ITVConfigurational)divecesDictionary[id]).Configurations.DecreaseContrast();
            changeContrastPanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.Contrast.ToString();
            colorModePanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.ColorMode.ToString();
        }

        private void increaseContrastButton_Click(object sender, EventArgs e)
        {
            ((ITVConfigurational)divecesDictionary[id]).Configurations.IncreaseContrast();
            changeContrastPanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.Contrast.ToString();
            colorModePanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.ColorMode.ToString();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            changeChannelsPanel.Visible = !changeChannelsPanel.Visible;
            changeVolumePanel.Visible = !changeVolumePanel.Visible;
            tvConfigurations.Visible = !tvConfigurations.Visible;
        }

        private void decreaseIntensityButton_Click(object sender, EventArgs e)
        {
            ((ITVConfigurational)divecesDictionary[id]).Configurations.DecreaseIntensity();
            changeIntensityPanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.Intensity.ToString();
            imageModePanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.ImageMode.ToString();
        }

        private void increaseIntensityButton_Click(object sender, EventArgs e)
        {
            ((ITVConfigurational)divecesDictionary[id]).Configurations.IncreaseIntensity();
            changeIntensityPanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.Intensity.ToString();
            imageModePanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.ImageMode.ToString();
        }

        private void changeColorModeButton_Click(object sender, EventArgs e)
        {
            ((ITVConfigurational)divecesDictionary[id]).Configurations.ChangeColorMode();
            colorModePanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.ColorMode.ToString();
            changeContrastPanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.Contrast.ToString();
        }

        private void changeImageModeButton_Click(object sender, EventArgs e)
        {
            ((ITVConfigurational)divecesDictionary[id]).Configurations.ChangeImageMode();
            imageModePanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.ImageMode.ToString();
            changeIntensityPanel.ValueLabel.Text = ((ITVConfigurational)divecesDictionary[id]).Configurations.Intensity.ToString();
        }

        private void changeFreezeModeButton_Click(object sender, EventArgs e)
        {
            ((IFreezeModal)divecesDictionary[id]).ChangeMode();
            freezeModePanel.ValueLabel.Text = ((IFreezeModal)divecesDictionary[id]).Mode.ToString();

            if(divecesDictionary[id] is IThermal)
                {
                changeTemperaturePanel.ValueLabel.Text = ((IThermal)divecesDictionary[id]).Temperature.ToString();
                }
        }

        private void channelsButton_Click(object sender, EventArgs e)
        {
            channelsList.Visible = !channelsList.Visible;
        }

        private void decreaseChannelButton_Click(object sender, EventArgs e)
        {
            ((IChannels)divecesDictionary[id]).PrevChannel();
            changeChannelsPanel.ValueLabel.Text = ((IChannels)divecesDictionary[id]).CurrentChannel.ToString();
        }

        private void increaseChannelButton_Click(object sender, EventArgs e)
        {
            ((IChannels)divecesDictionary[id]).NextChannel();
            changeChannelsPanel.ValueLabel.Text = ((IChannels)divecesDictionary[id]).CurrentChannel.ToString();
        }

        private void decreaseVolumeButton_Click(object sender, EventArgs e)
        {
            ((IVolume)divecesDictionary[id]).DecreaseVolume();
            changeVolumePanel.ValueLabel.Text = ((IVolume)divecesDictionary[id]).Volume.ToString();
        }

        private void increaseVolumeButton_Click(object sender, EventArgs e)
        {
            ((IVolume)divecesDictionary[id]).IncreaseVolume();
            changeVolumePanel.ValueLabel.Text = ((IVolume)divecesDictionary[id]).Volume.ToString();
        }

        private void decreasePressureButton_Click(object sender, EventArgs e)
        {
            ((IPressure)divecesDictionary[id]).DecreasePressure();
            changePressurePanel.ValueLabel.Text = ((IPressure)divecesDictionary[id]).Pressure.ToString();
        }

        private void increasePressureButton_Click(object sender, EventArgs e)
        {
            ((IPressure)divecesDictionary[id]).IncreasePressure();
            changePressurePanel.ValueLabel.Text = ((IPressure)divecesDictionary[id]).Pressure.ToString();
        }

        private void decreaseTemperatureButton_Click(object sender, EventArgs e)
        {
            ((IThermal)divecesDictionary[id]).DecreaseTemperature();
            changeTemperaturePanel.ValueLabel.Text = ((IThermal)divecesDictionary[id]).Temperature.ToString();

            if (divecesDictionary[id] is IFreezeModal)
            {
                
                freezeModePanel.ValueLabel.Text = ((IFreezeModal)divecesDictionary[id]).Mode.ToString();
            }
        }

        private void increaseTemperatureButton_Click(object sender, EventArgs e)
        {
            ((IThermal)divecesDictionary[id]).IncreaseTemperature();
            changeTemperaturePanel.ValueLabel.Text = ((IThermal)divecesDictionary[id]).Temperature.ToString();

            if (divecesDictionary[id] is IFreezeModal)
            {

                freezeModePanel.ValueLabel.Text = ((IFreezeModal)divecesDictionary[id]).Mode.ToString();
            }
        }

        private void decreaseBrightnessButton_Click(object sender, EventArgs e)
        {
            ((IBrightness)divecesDictionary[id]).DecreaseBrightness();
            changeBrightnessPanel.ValueLabel.Text = ((IBrightness)divecesDictionary[id]).Brightness.ToString();
        }

        private void increaseBrightnessButton_Click(object sender, EventArgs e)
        {
            ((IBrightness)divecesDictionary[id]).IncreaseBrightness();
            changeBrightnessPanel.ValueLabel.Text = ((IBrightness)divecesDictionary[id]).Brightness.ToString();
        }

        public void Switch_Click(object sender, EventArgs e)
        {
            ((ISwitchable)divecesDictionary[id]).Switch();
            CssClass = ((ISwitchable)divecesDictionary[id]).State ? "device" : "switchOffdevice";

            foreach(Control control in Controls)
            {
                if (control is Button)
                {
                    if (((Button)control).CssClass == "setButton" || ((Button)control).CssClass == "buttonOff")
                        ((Button)control).CssClass = (((ISwitchable)divecesDictionary[id]).State) ? "setButton" : "buttonOff";
                }
                else
                    foreach (Control control2 in control.Controls)
                    {
                        if (control2 is Button)
                        {
                            if (((Button)control2).CssClass == "smallButtonOff" || ((Button)control2).CssClass == "smallButton")
                                ((Button)control2).CssClass = (((ISwitchable)divecesDictionary[id]).State) ? "smallButton" : "smallButtonOff";

                        }
                    }
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            divecesDictionary.Remove(id);
            Parent.Controls.Remove(this);
        }
    }

    
}