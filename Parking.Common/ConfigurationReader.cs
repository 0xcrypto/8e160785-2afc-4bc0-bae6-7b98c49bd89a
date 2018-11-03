using System.IO;
using Newtonsoft.Json;

namespace Parking.Common
{
    public sealed class ConfigurationReader
    {
        private const string configurationFileName = "DeviceConfig.json";
        private static readonly string ConfigFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), configurationFileName);

        //TD Specific
        private static TDClientSetting tDClientSetting = null;
        private static readonly object FileLock = new object();

        public static TDClientSetting GetConfigurationSettings()
        {
            try
            {
                if (tDClientSetting != null) return tDClientSetting;
                lock (FileLock)
                {                      
                    if (!File.Exists(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), "DeviceConfig.json")))
                    {
                        FileLogger.Log($"Configuration settings could not be loaded successfully as DeviceConfig.json was not found in the directory");
                    }
                    using (StreamReader reader = new StreamReader(ConfigFilePath))
                    {
                        tDClientSetting = JsonConvert.DeserializeObject<TDClientSetting>(reader.ReadToEnd());
                    }
                }                
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Configuration settings could not be loaded successfully as : {e.Message}");
                throw;
            }
            return tDClientSetting;
        }              
    }
}
