using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;

namespace SmartPartsFrame.Model.DatabaseTools.SQL
{
    ///Singletone
    internal static class ConnectionModel
    {
        private static volatile string connectionString = string.Empty;
        private static object syncObject = new Object();

        public static string ConnectionString
        {
            get
            {
                return GetConnectionString();
            }
        }

        private static string GetConnectionString()
        {
            lock (syncObject)
            {
                string resultConnectionString = "";
                if (string.IsNullOrEmpty(connectionString))
                {
                    if (HttpContext.Current != null)
                    {
                        resultConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    }
                    else
                    {
                        string configFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;//"app.config";

                        ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
                        configFile.ExeConfigFilename = Path.Combine(Environment.CurrentDirectory, configFileName);

                        System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
                        if (config.HasFile)
                        {
                            resultConnectionString = config.ConnectionStrings.ConnectionStrings["ConnectionModelsConnectionString"].ConnectionString;// config.AppSettings.Settings["ConnectionString"].Value;
                        }
                        else
                        {
                            throw new Exception(string.Format(Properties.Resources.ConnectionModel_ConfigurationFileError, configFileName));
                        }
                    }
                    connectionString = resultConnectionString;
                }
            }

            return connectionString;
        }
    }
}
