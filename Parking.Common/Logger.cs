using System;
using System.IO;

namespace Parking.Common
{
    public class FileLogger
    {
        private const string logFileName = "logs.txt";
        private static string filePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), logFileName);
        public static void Log(string message)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                try
                {
                    streamWriter.Write($"{DateTime.Now.ToString()} :: {message}{Environment.NewLine}");
                    streamWriter.Close();
                }
                catch (System.Exception)
                {

                }
            }
        }
    }
}
