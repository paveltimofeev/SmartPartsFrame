using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Model.Plugin
{
    public delegate void PluginLoadedEventHandler<T>(object sender, PluginLoadedEventArgs<T> e) where T : IPlugin;

    /// <summary>
    /// Provides data about loaded plugin.
    /// </summary>
    public class PluginLoadedEventArgs<T> : PluginLoadingBaseEventArgs<T>
        where T : IPlugin 
    {
        public PluginLoadedEventArgs(T loadedPlugin)
            : base(loadedPlugin)
        {
            ;
        }
    }
}
