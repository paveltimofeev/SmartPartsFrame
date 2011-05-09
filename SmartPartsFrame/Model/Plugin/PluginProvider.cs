using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using SmartPartsFrame.Model.Plugin;
using SmartPartsFrame.Model.DatabaseTools.SQL;
using System.Data;

namespace SmartPartsFrame.Model.Plugin
{
    /// <summary>
    /// Provides support of loading plugins.
    /// </summary>
    public class PluginProvider<T>
        where T : class, IPlugin
    {
        private FileSystemWatcher watcher;

        public event PluginListChangedEventHandler<T> PluginListChanged;
        public event PluginLoadedEventHandler<T> PluginLoaded;
        public event PluginUnLoadedEventHandler<T> PluginUnLoaded;

        public string PluginDirectory { get; private set; }
        public string PluginExtension { get; private set; }
        public Dictionary<string, T> Plugins { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="directory">This is relative path to plugin's directory (for example \plugins)</param>
        /// <param name="extension">Plugin file's exstension mask (for example *.dll)</param>
        public PluginProvider(string directory, string extension)
        {
            this.PluginDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), directory);
            this.PluginExtension = extension;
            this.Plugins = new Dictionary<string, T>();

            SqlModel m = new SqlModel("my_conn_str", "select * from products where name = @type");
            string[] typesArray = m.Add("@type", SqlDbType.NVarChar, "Type1").Fill<string>(0);
        }

        /// <summary>
        /// Initializes loader's work
        /// </summary>
        /// <param name="syncObj">Synchronize object (current form for example)</param>
        public void StartWatch(ISynchronizeInvoke syncObj)
        {
            if (Directory.Exists(PluginDirectory))
            {
                this.Plugins.Clear();

                foreach (string file in Directory.GetFiles(PluginDirectory, PluginExtension))
                {
                    LoadDll(file);
                }

                this.watcher = new FileSystemWatcher(PluginDirectory, PluginExtension);
                this.watcher.IncludeSubdirectories = false;
                this.watcher.SynchronizingObject = syncObj;
                this.watcher.Created += new FileSystemEventHandler(watcher_Created);
                this.watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
                this.watcher.EnableRaisingEvents = true;
            }
            else
            {
                throw new DirectoryNotFoundException(PluginDirectory);
            }
        }

        /// <summary>
        /// Returns IPlugin by name from list of loaded plugins.
        /// </summary>
        /// <param name="name">Plugin name</param>
        /// <returns></returns>
        public T GetPlugin(string name)
        {
            if (Plugins.ContainsKey(name))
                return this.Plugins[name];
            else
                throw new PluginNotFoundException(name);
        }

        private void LoadDll(string fileName)
        {
            foreach (T plugin in PluginsInDll(fileName))
            {
                if (!Plugins.ContainsKey(plugin.PluginName))
                {
                    this.Plugins.Add(plugin.PluginName, plugin);

                    PluginListChangedEventArgs<T> ec = new PluginListChangedEventArgs<T>(Plugins);
                    this.onPluginListChanged(ec);

                    PluginLoadedEventArgs<T> e = new PluginLoadedEventArgs<T>(plugin);
                    this.onPluginLoaded(e);
                }
            }
        }

        private void UnLoadDll(string fileName)
        {
            foreach (T plugin in PluginsInDll(fileName))
            {
                this.Plugins.Remove(plugin.PluginName);

                PluginListChangedEventArgs<T> ec = new PluginListChangedEventArgs<T>(Plugins);
                this.onPluginListChanged(ec);

                PluginUnLoadedEventArgs<T> e = new PluginUnLoadedEventArgs<T>(plugin);
                this.onPluginUnLoaded(e);
            }
        }

        private IEnumerable<T> PluginsInDll(string fileName)
        {
            Assembly a = Assembly.LoadFrom(fileName);
            Type[] types = a.GetTypes();

            foreach (Type t in types)
            {
                //object[] pluginAttributes = t.GetCustomAttributes(typeof(SearchPluginAttrubite), false);

                //if (pluginAttributes.Length != 0)
                //{
                    object typeInstance = Activator.CreateInstance(t);
                    T plugin = typeInstance as T;

                    if (plugin != null)
                    {
                        yield return plugin;
                    }
                //}
            }
        }

        #region Event Handlers

        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            this.LoadDll(e.FullPath);
        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            this.UnLoadDll(e.FullPath);
        }

        #endregion

        protected void onPluginListChanged(PluginListChangedEventArgs<T> e)
        {
            PluginListChangedEventHandler<T> handler = PluginListChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void onPluginLoaded(PluginLoadedEventArgs<T> e)
        {
            PluginLoadedEventHandler<T> handler = PluginLoaded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void onPluginUnLoaded(PluginUnLoadedEventArgs<T> e)
        {
            PluginUnLoadedEventHandler<T> handler = PluginUnLoaded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}