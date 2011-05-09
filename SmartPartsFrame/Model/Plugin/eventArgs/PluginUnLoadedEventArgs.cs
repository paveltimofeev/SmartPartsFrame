using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Model.Plugin
{
    public delegate void PluginUnLoadedEventHandler<T>(object sender, PluginUnLoadedEventArgs<T> e) where T:IPlugin;

    /// <summary>
    /// Provides data about unloaded plugin
    /// </summary>
    public class PluginUnLoadedEventArgs<T> : PluginLoadingBaseEventArgs<T>
        where T : IPlugin 
    {
        public PluginUnLoadedEventArgs(T unLoadedPlugin)
            : base(unLoadedPlugin)
        {
            ;
        }
    }
}
