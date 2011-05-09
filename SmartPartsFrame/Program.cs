using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartPartsFrame.Model.Security;

namespace SmartPartsFrame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserIdentity.Authorization();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SmartPartsForm());
        }
    }
}
