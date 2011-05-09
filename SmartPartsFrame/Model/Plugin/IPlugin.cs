using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartPartsFrame.Model.Plugin
{
    /// <summary>
    /// This interface (or its inherites) must be transfered to common lib and used for plugins implementation.
    /// </summary>

    public interface IPlugin 
    { 
        string PluginName { get; } 
    }

    public interface IDisplayablePlugin : IPlugin
    {
        Control UserControl { get; }
    }
}
