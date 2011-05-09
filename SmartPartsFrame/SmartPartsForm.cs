using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SmartPartsFrame.SmartParts;
using SmartPartsFrame.SmartParts.Common;
using SmartPartsFrame.View.SmartParts;
using SmartPartsFrame.View.SmartParts.General;

namespace SmartPartsFrame
{
    public partial class SmartPartsForm : Form
    {
        public SmartPartsForm()
        {
            InitializeComponent();
            InitializeSmartPart();
        }

        void InitializeSmartPart()
        {
            SmartPartHost hostFiles = new SmartPartHost(panelFiles);
            hostFiles.HostName = "Simple host";
            hostFiles.SmartPartAcivated += new EventHandler<SmartPartAcivatedEventArgs>(host_SmartPartAcivated);

            DefaultSmartPart def = new DefaultSmartPart();
            def.SmartPartRegister(hostFiles, tsDefault);

            hostFiles.ActivateSmartPart(def);
        }

        void host_SmartPartAcivated(object sender, SmartPartAcivatedEventArgs e)
        {
            this.Text = string.Format("{0} - {1}", e.HostName, e.SmartPartName);

            if (e.SmartPartIcon != null)
                this.Icon = e.SmartPartIcon;
        }
    }
}
