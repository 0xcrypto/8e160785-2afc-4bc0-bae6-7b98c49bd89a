using Newtonsoft.Json;
using System.IO;
namespace Parking.Common
{
    public sealed class MPSConfigurationReader
    {
        private const string configurationFileName = "DeviceConfig.json";
        private static readonly string ConfigFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), configurationFileName);

        //MPS Specific
        private static MPSSettings mpsSetting = null;
        private static readonly object FileLock = new object();

        public static MPSSettings GetConfigurationSettings()
        {
            try
            {
                if (mpsSetting != null) return mpsSetting;
                lock (FileLock)
                {
                    if (!File.Exists(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), "DeviceConfig.json")))
                    {
                        FileLogger.Log($"Configuration settings could not be loaded successfully as DeviceConfig.json was not found in the directory");
                    }
                    using (StreamReader reader = new StreamReader(ConfigFilePath))
                    {
                        mpsSetting = JsonConvert.DeserializeObject<MPSSettings>(reader.ReadToEnd());
                    }
                }
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Configuration settings could not be loaded successfully as : {e.Message}");
                throw;
            }
            return mpsSetting;
        }
    }
}
