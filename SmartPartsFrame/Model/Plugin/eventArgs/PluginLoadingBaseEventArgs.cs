using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Model.Plugin
{
    /// <summary>
    /// PluginLoadingBaseEventArgs is base class for classes containing data of loading plugins.
    /// </summary>
    public abstract class PluginLoadingBaseEventArgs<T> : EventArgs
        where T: IPlugin
    {
        public PluginLoadingBaseEventArgs(T plugin)
        {
            this.Plugin = plugin;
        }

        /// <summary>
        /// Name of the plugin.
        /// </summary>
        public string PluginName
        {
            get { return this.Plugin.PluginName; }
        }

        /// <summary>
        /// Plugin
        /// </summary>
        public T Plugin
        {
            get;
            protected set;
        }
    }
}
