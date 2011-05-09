using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using SmartPartsFrame.Patterns.EventBasedAsynchronousPattern.eventArgs;

namespace SmartPartsFrame.Patterns.EventBasedAsynchronousPattern
{
    internal class ConcreteActionAsync: AsynchronousActionsBase
    {
        public ConcreteActionAsync(object userState)
            : base(userState)
        {
            ;
        }

        protected override void Operation(object userState)
        {
            ///
            AsyncOperation operation = (AsyncOperation)userStates[userState];
            operation.Post(new SendOrPostCallback(PostProgress), new AsynchronousActionsEventArgs());
        }
    }
}
