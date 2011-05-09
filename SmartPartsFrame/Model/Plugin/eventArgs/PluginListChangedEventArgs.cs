using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Model.Plugin
{
    public delegate void PluginListChangedEventHandler<T>(object sender, PluginListChangedEventArgs<T> e) where T : IPlugin;

    /// <summary>
    /// Provades data about changhed list of plugins.
    /// </summary>
    public class PluginListChangedEventArgs<T> : EventArgs
        where T : IPlugin 
    {
        public PluginListChangedEventArgs(Dictionary<string, T> plugins)
        {
            this.Plugins = plugins;
            this.PluginNames = new string[plugins.Count];

            plugins.Keys.CopyTo(PluginNames, 0);
        }

        /// <summary>
        /// Available plugins.
        /// </summary>
        public Dictionary<string, T> Plugins { get; private set; }

        /// <summary>
        /// Names of available plugins.
        /// </summary>
        public string[] PluginNames { get; private set; }
    }
}
