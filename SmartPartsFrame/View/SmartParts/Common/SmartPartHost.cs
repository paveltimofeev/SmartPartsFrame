using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SmartPartsFrame.View.Interface;
using SmartPartsFrame.Properties;

namespace SmartPartsFrame.SmartParts.Common
{
    public class SmartPartHost
    {
        Control hostPanel;

        public SmartPartHost(Control hostPanel)
        {
            this.hostPanel = hostPanel;
        }

        public void ActivateSmartPart(ISmartPartView smartPart)
        {
            if (smartPart is UserControl)
            {
                hostPanel.Controls.Clear();
                hostPanel.Controls.Add((UserControl)smartPart);
                smartPart.Dock = DockStyle.Fill;

                SmartPartAcivatedEventArgs ea = new SmartPartAcivatedEventArgs();
                ea.SmartPartName = smartPart.SmartPartName;
                ea.SmartPartIcon = smartPart.SmartPartIcon;
                ea.HostName = this.HostName;
                ea.SmartPart = smartPart;
                onSmartPartAcivated(ea);
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.SmartPartHost_ActivateSmartPartError, smartPart.GetType()));
            }
        }

        public event EventHandler<SmartPartAcivatedEventArgs> SmartPartAcivated;

        protected void onSmartPartAcivated(SmartPartAcivatedEventArgs ea)
        {
            EventHandler<SmartPartAcivatedEventArgs> handler = SmartPartAcivated;
            if (handler != null)
            {
                handler(this, ea);
            }
        }

        public string HostName { get; set; }
    }
}
