using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SmartPartsFrame.SmartParts.Common;
using SmartPartsFrame.Presenter;
using SmartPartsFrame.View.Interface;
using System.Text.RegularExpressions;
using System.Security.Permissions;

namespace SmartPartsFrame.View.SmartParts
{
    public partial class DefaultSmartPart : SmartPartBase, IDefaultView
    {
        DefaultPresenter presenter;

        public DefaultSmartPart()
        {
            InitializeComponent();

            presenter = new DefaultPresenter(this);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            presenter.ViewChange();
        }
    }
}
