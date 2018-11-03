using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking.Common
{
    public class TDClientSetting
    {
        public string TDClientDeviceId { get; set; }        
        public string UserId { get; set; }
        public string Password { get; set; }
        public string LongLat { get; set; }
        public string PLCBoardConnectPort { get; set; }
        public string DriverCameraIPAddress { get; set; }
        public string DriverCameraUsername { get; set; }
        public string DriverCameraPassword { get; set; }
        public string VehicleCameraIPAddress { get; set; }
        public string VehicleCameraUsername { get; set; }
        public string VehicleCameraPassword { get; set; }
        public string TdServerIPAddress { get; set; }
        public string TdServerPort { get; set; }
        public string TdServerUsername { get; set; }
        public string TdServerPassword { get; set; }
    }
}
