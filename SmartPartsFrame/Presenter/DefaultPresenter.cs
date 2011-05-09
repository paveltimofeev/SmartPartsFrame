using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using SmartPartsFrame.View.Interface;
using SmartPartsFrame.Model;
using SmartPartsFrame.Model.DatabaseTools.SQL;
using SmartPartsFrame.Model.Security;
using SmartPartsFrame.Model.Plugin;
using SmartPartsFrame.Patterns.Singleton;
using SmartPartsFrame.Patterns.FactoryMethod;
using SmartPartsFrame.Patterns.Command;

namespace SmartPartsFrame.Presenter
{
    internal class DefaultPresenter
    {
        IDefaultView view = null;
        DefaultModel model = new DefaultModel();

        public DefaultPresenter(IDefaultView view)
        {
            this.view = view;
        }

        public void ViewChange()
        {
            //test
            view.Controls["btnTest"].BackColor = Color.Red;
            view.Controls["btnTest"].Text = model.GetCurrentTitle();
        }
    }
}
