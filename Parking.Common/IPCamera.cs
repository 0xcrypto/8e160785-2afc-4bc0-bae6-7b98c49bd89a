using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using System.IO;

namespace Parking.Common
{
    public class IPCamera
    {
        private const string DRIVER_IMAGE_URL = "https://cleanvehiclerebate.org/sites/default/files/2014_Hyundai_Tucson_Fuel_Cell.jpg";
        private const string VEHICLE_IMAGE_URL = "https://cleanvehiclerebate.org/sites/default/files/2014_Hyundai_Tucson_Fuel_Cell.jpg";

        //TODO:Use the comment code in production
        //private static string _driverImageCameraIP = null;
        //private static string _vehicleImageCameraIP = null;

        public static Bitmap GetDriverImage()
        {
            Bitmap image = null;
            try
            {
                //var driverImageCameraIP = _driverImageCameraIP == null ? GetDriverCameraIPAddress() : _driverImageCameraIP;
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(driverImageCameraIP);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(DRIVER_IMAGE_URL);
                request.AllowWriteStreamBuffering = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();

                if (stream != null)
                {
                    image = new Bitmap(stream);   
                }
            }
            catch (Exception)
            {
                image = new Bitmap(1,1);
            }

            return image;
        }

        //private static string GetDriverCameraIPAddress()
        //{
        //    try
        //    {
        //        var driverImageCameraIP = ConfigurationReader.GetConfigurationSettings().DriverCameraIPAddress;
        //        if (string.IsNullOrEmpty(driverImageCameraIP.ToString()))
        //        {
        //            throw  new Exception(message: "Driver Camera IP was not found in Configuration File");
        //        }

        //        _driverImageCameraIP = driverImageCameraIP;
        //        return driverImageCameraIP;
        //    }
        //    catch (Exception exception)
        //    {                
        //        FileLogger.Log($"Driver Camera IP Address could not be loaded successfully as : {exception.Message}");
        //        throw;
        //    }
        //}

        //private static string GetVehicleCameraIPAddress()
        //{
        //    try
        //    {
        //        var vehicleImageCameraIP = ConfigurationReader.GetConfigurationSettings().VehicleCameraIPAddress;
        //        if (string.IsNullOrEmpty(vehicleImageCameraIP.ToString()))
        //        {
        //            throw new Exception(message: "Vehicle Camera IP was not found in Configuration File");
        //        }
        //        _vehicleImageCameraIP = vehicleImageCameraIP;
        //        return vehicleImageCameraIP;
        //    }
        //    catch (Exception exception)
        //    {
        //        FileLogger.Log($"Vehicle Camera IP Address could not be loaded successfully as : {exception.Message}");
        //        throw;
        //    }
        //}

        public static Bitmap GetVehicleImage()
        {
            Bitmap image = null;
            try
            {
                //var vehicleImageCameraIP = _vehicleImageCameraIP == null ? GetVehicleCameraIPAddress() : _vehicleImageCameraIP;
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(vehicleImageCameraIP);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(VEHICLE_IMAGE_URL);
                request.AllowWriteStreamBuffering = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();

                if (stream != null)
                {
                    image = new Bitmap(stream);
                }
            }
            catch (Exception)
            {
                image = new Bitmap(1, 1);
            }

            return image;
        }
    }
}
