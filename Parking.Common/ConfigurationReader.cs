using System.IO;
using Newtonsoft.Json;
using Parking.Common.Enums;

namespace Parking.Common
{
    public sealed class ConfigurationReader
    {
        private const string configurationFileName = "DeviceConfig.json";
        private static readonly string ConfigFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), configurationFileName);

        //TD Specific
        private static object settings = null;
        private static readonly object FileLock = new object();

        public static object GetConfigurationSettings(Application application)
        {
            try
            {
                if (settings != null) return settings;

                
                lock (FileLock)
                {                      
                    if (!File.Exists(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), "DeviceConfig.json")))
                    {
                        FileLogger.Log($"Configuration settings could not be loaded successfully as DeviceConfig.json was not found in the directory");
                    }
                    using (StreamReader reader = new StreamReader(ConfigFilePath))
                    {
                        switch (application)
                        {
                            case Application.TicketDispenserClient:
                                settings = JsonConvert.DeserializeObject<TickerDispenserClientSettings>(reader.ReadToEnd());
                                break;
                            case Application.TickerDispenserServer:
                                settings = JsonConvert.DeserializeObject<TicketDispenserServerSettings>(reader.ReadToEnd());
                                break;
                            case Application.ManualPayStation:
                                settings = JsonConvert.DeserializeObject<ManualPayStationSettings>(reader.ReadToEnd());
                                break;
                            default:
                                break;
                        }
                    }
                }                
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Configuration settings could not be loaded successfully as : {e.Message}");
                throw;
            }
            return settings;
        }              
    }
}
