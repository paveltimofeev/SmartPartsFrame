using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartPartsFrame.View.Interface
{
    internal interface IDefaultView : ISmartPartView
    {
        void Hide();
        void Refresh();
        void Show();
    }
}

