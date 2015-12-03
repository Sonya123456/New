using SmartHouse.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SmartHouse.Controls
{
    public class ChangePanel: Panel
    {

        public Label TextLabel { get; set; }
        public Label ValueLabel { get; set; }
        public Button IncreaseButton { get; set; }
        public Button DecreaseButton { get; set; }

        public ChangePanel(string id,string text, string value, bool state)
        {
            
            TextLabel = new Label();
            TextLabel.ID = "text"+ text + "Label-" + id;
            TextLabel.Text = text;
            TextLabel.CssClass = "feature";

            ValueLabel = new Label();
            ValueLabel.ID = "value"+ text + "Label-" + id;
            ValueLabel.Text = value;
            ValueLabel.CssClass = "feature";

            IncreaseButton = new Button();
            IncreaseButton.ID = "increase"+ text + "Btn-" + id;
            IncreaseButton.Text = "+";
           
            
            IncreaseButton.CssClass = (state) ? "smallButton" : "smallButtonOff";
            

            DecreaseButton = new Button();
            DecreaseButton.ID = "decrease" + text + "Btn-" + id;
            DecreaseButton.Text = "-";
            
            DecreaseButton.CssClass = IncreaseButton.CssClass;

            Controls.Add(TextLabel);
            Controls.Add(DecreaseButton);
            Controls.Add(ValueLabel);
            Controls.Add(IncreaseButton);
        }

        
    }
}