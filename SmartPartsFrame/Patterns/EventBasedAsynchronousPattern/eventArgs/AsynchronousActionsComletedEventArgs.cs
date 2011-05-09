using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SmartPartsFrame.Patterns.EventBasedAsynchronousPattern.eventArgs
{
    public delegate void AsynchronousActionsComletedEventHandler(object sender, AsynchronousActionsComletedEventArgs e);

    public class AsynchronousActionsComletedEventArgs : AsyncCompletedEventArgs
    {
        public AsynchronousActionsComletedEventArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
            ;
        }
    }
}
