using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Model.Plugin
{
    public class PluginNotFoundException : Exception
    {
        public PluginNotFoundException(string pluginName)
            : this(pluginName, "Plugin Not Found")
        {
            ;
        }

        public PluginNotFoundException(string pluginName, string message)
            : base(message)
        {
            this.PluginName = pluginName;
        }

        public string PluginName { get; private set; }
    }
}
