namespace Parking.Common
{
    public class ManualPayStationSettings
    {
        public string MPSDeviceID { get; set; }
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public string TdServerIPAddress { get; set; }
        public string TdServerPort { get; set; }
        public string TdServerUsername { get; set; }
        public string TdServerPassword { get; set; }
        public string VehicleStatusPassword { get; set; }
        public string FourWheelerParkingSpace { get; set; }
        public string TwoWheelerParkingSpace { get; set; }
        public string FourWheelerParkingRatePerHour { get; set; }
        public string TwoWheelerParkingRatePerHour { get; set; }
        public string LostTicketPenality { get; set; }
    }
}
