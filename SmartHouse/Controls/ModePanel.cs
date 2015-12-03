using SmartHouse.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SmartHouse.Controls
{
    public class ModePanel:Panel
    {
        
        protected Label TextLabel { get; set; }
        public Label ValueLabel { get; set; }
        public Button ChangeModeButton { get; set; }

        public ModePanel(string id, string text, string value, bool state)
        {
            TextLabel = new Label();
            TextLabel.ID = "text"+ text + "Lable-" + id;
            TextLabel.Text = text;
            TextLabel.CssClass = "feature";

            ValueLabel = new Label();
            ValueLabel.ID = "value" + text + "Lable-" + id;
            ValueLabel.Text = value;
            ValueLabel.CssClass = "feature";

            ChangeModeButton = new Button();
            ChangeModeButton.ID = text + "Btn-" + id;
            ChangeModeButton.Text = ">";

           
            ChangeModeButton.CssClass = (state) ? "smallButton" : "smallButtonOff";

            Controls.Add(TextLabel);
            Controls.Add(ValueLabel);
            Controls.Add(ChangeModeButton);

        }


    }
}