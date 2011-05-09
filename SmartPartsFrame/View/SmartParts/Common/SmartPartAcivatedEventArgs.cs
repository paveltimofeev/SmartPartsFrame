using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SmartPartsFrame.View.Interface;

namespace SmartPartsFrame.SmartParts.Common
{
    public class SmartPartAcivatedEventArgs : EventArgs
    {
        public string HostName { get; set; }
        public string SmartPartName { get; set; }
        public Icon SmartPartIcon { get; set; }
        public ISmartPartView SmartPart { get; set; }
    }
}
