using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Collections;
using SmartPartsFrame.Patterns.EventBasedAsynchronousPattern.eventArgs;

namespace SmartPartsFrame.Patterns.EventBasedAsynchronousPattern
{
    internal class AsynchronousActionsBase
    {
        private Object syncObj = new Object();
        protected Hashtable userStates = new Hashtable();
        public bool IsBusy { get; private set; }
        public bool Canceled { get; private set; }

        public AsynchronousActionsBase(object userState)
        {
            AsyncOperation operation = AsyncOperationManager.CreateOperation(userState);
            userStates.Add(userState, operation);
        }

        public void StartAsync(object userState)
        {
            Reset(userState);

            this.IsBusy = true;

            AsynchronousOperationHandler handler = new AsynchronousOperationHandler(this.AsynchronousOperation);
            handler.BeginInvoke(null, null, userState);

            AsyncOperation operation = (AsyncOperation)userStates[userState];
            operation.Post(new SendOrPostCallback(PostStarted), new AsynchronousActionsEventArgs());
        }

        public void CancelAsync(object userState)
        {
            Canceled = true;
            AsyncOperation operation = (AsyncOperation)userStates[userState];

            operation.PostOperationCompleted(
                new SendOrPostCallback(PostCanceled),
                new AsynchronousActionsComletedEventArgs(null, Canceled, userState));
        }

        private delegate void AsynchronousOperationHandler(object userState);

        private void AsynchronousOperation(object userState)
        {                
            AsyncOperation operation = (AsyncOperation)userStates[userState];
            Exception exception = null;

            try
            {
                Operation(userState);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                operation.PostOperationCompleted(
                    new SendOrPostCallback(PostCompleted), 
                    new AsynchronousActionsComletedEventArgs(exception, Canceled, userState));

                Reset(userState);
            }
        }

        /// <summary>
        /// Override this method to implement your logic.
        /// AsyncOperation operation = (AsyncOperation)userStates[userState];
        /// operation.Post(new SendOrPostCallback(PostProgress), new AsynchronousActionsEventArgs());
        /// </summary>
        /// <param name="userState"></param>
        protected virtual void Operation(object userState)
        {
            ///operations;
        }

        private void Reset(object userState)
        {
            AsyncOperation operation = (AsyncOperation)userStates[userState];
            operation = AsyncOperationManager.CreateOperation(userState);
            this.IsBusy = false;
            this.Canceled = false;
        }

        #region Posts

        private void PostStarted(object obj)
        {
            AsynchronousActionsEventArgs e = obj as AsynchronousActionsEventArgs;
            if (e != null)
                onStarted(e);
        }

        protected void PostProgress(object obj)
        {
            AsynchronousActionsEventArgs e = obj as AsynchronousActionsEventArgs;
            if (e != null)
                onProgress(e);
        }

        private void PostCanceled(object obj)
        {
            IsBusy = false;

            AsynchronousActionsComletedEventArgs e = obj as AsynchronousActionsComletedEventArgs;
            if (e != null)
                onCancel(e);
        }

        private void PostCompleted(object obj)
        {
            IsBusy = false;

            AsynchronousActionsComletedEventArgs e = obj as AsynchronousActionsComletedEventArgs;
            if (e != null)
                onComplete(e);
        }

        #endregion

        #region Events

        public event AsynchronousActionsEventHandler ActionStarted;
        public event AsynchronousActionsEventHandler ActionProgress;
        public event AsynchronousActionsComletedEventHandler ActionCanceled;
        public event AsynchronousActionsComletedEventHandler ActionCompleted;

        private void onStarted(AsynchronousActionsEventArgs e)
        {
            AsynchronousActionsEventHandler handler = ActionStarted;
            if (handler != null)
                handler(this, e);
        }

        private void onProgress(AsynchronousActionsEventArgs e)
        {
            AsynchronousActionsEventHandler handler = ActionProgress;
            if (handler != null)
                handler(this, e);
        }

        private void onCancel(AsynchronousActionsComletedEventArgs e)
        {
            AsynchronousActionsComletedEventHandler handler = ActionCanceled;
            if (handler != null)
                handler(this, e);
        }

        private void onComplete(AsynchronousActionsComletedEventArgs e)
        {
            AsynchronousActionsComletedEventHandler handler = ActionCompleted;
            if (handler != null)
                handler(this, e);
        }

        #endregion
    }
}