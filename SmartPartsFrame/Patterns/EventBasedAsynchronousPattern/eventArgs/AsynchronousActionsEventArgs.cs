using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SmartPartsFrame.Patterns.EventBasedAsynchronousPattern.eventArgs
{
    public delegate void AsynchronousActionsEventHandler(object sender, AsynchronousActionsEventArgs e);

    public class AsynchronousActionsEventArgs : EventArgs
    {

    }
}
