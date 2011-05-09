using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartPartsFrame.View.Interface
{
    interface ITreeSmartPart: ISmartPartView
    {
        TreeNode CurrentNode { get; set; }
        void AddNodes(string[] nodes);
    }
}
