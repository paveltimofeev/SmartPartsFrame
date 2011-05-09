using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SmartPartsFrame.View.Interface;
using SmartPartsFrame.Properties;

namespace SmartPartsFrame.SmartParts.Common
{
    public partial class SmartPartBase : UserControl, ISmartPartView
    {
        private SmartPartHost smartPartHost;
        private ToolStripItem smartPartButton;
        string smartPartName = "SmartPartBase";
        Icon smartPartIcon = Resources.SmartPartBase_SmartPartIcon;

        public SmartPartBase()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [DisplayName("Smartpart Name")]
        public string SmartPartName
        {
            get { return smartPartName; }
            set { smartPartName = value; }
        }

        [Browsable(true)]
        [DisplayName("Smartpart Icon")]
        public Icon SmartPartIcon
        {
            get { return smartPartIcon; }
            set { smartPartIcon = value; }
        }
        
        [Browsable(true)]
        [DisplayName("Smartpart host panel")]
        public SmartPartHost SmartPartHost
        {
            get { return smartPartHost; }
            set { smartPartHost = value; }
        }

        [Browsable(true)]
        [DisplayName("Smartpart activate button")]
        public ToolStripItem SmartPartButton
        {
            get { return smartPartButton; }
            set 
            { 
                smartPartButton = value;

                if (smartPartButton != null)
                {
                    smartPartButton.Image = this.smartPartIcon.ToBitmap();
                    smartPartButton.Text = this.SmartPartName;
                    smartPartButton.Click += new EventHandler(button_Click);
                }
            }
        }

        /// <summary>
        /// Register smartpart at host and share with button
        /// </summary>
        /// <param name="host">Host control for smartpart</param>
        /// <param name="button">Button that activate this smartpart</param>
        public void SmartPartRegister(SmartPartHost host, ToolStripItem button)
        {
            this.SmartPartHost = host;
            this.SmartPartButton = button;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (this.smartPartHost != null)
            {
                smartPartHost.ActivateSmartPart(this);
            }
            else
            {
                throw new Exception(Resources.SmartPartBase_HostIsNullError);
            }
        }
    }
}
