using System;
using System.Collections.Generic;
using System.Text;
using SmartPartsFrame.SmartParts.Common;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace SmartPartsFrame.View.Interface
{
    public interface ISmartPartView : IComponent, ISmartPartViewBase
    {
        /*SmartParts interface*/

        string SmartPartName { get; set; }
        SmartPartHost SmartPartHost { get; set; }
        Icon SmartPartIcon { get; set; }
        void SmartPartRegister(SmartPartHost host, ToolStripItem button);

        /*UserControls interface*/

        bool Focus();
        void Hide();
        void Refresh();
        void Show();
        void Update();

        Color BackColor { get; set; }
        Image BackgroundImage { get; set; }
        BorderStyle BorderStyle { get; set; }
        Control.ControlCollection Controls { get; }
        Cursor Cursor { get; set; }
        DockStyle Dock { get; set; }
        bool Enabled { get; set; }
        Color ForeColor { get; set; }
        IntPtr Handle { get; }
        Point Location { get; set; }
        Padding Margin { get; set; }
        string Name { get; }
        object Tag { get; set; }
        Size Size { get; set; }
        bool Visible { get; set; }
    }
}
