namespace Parking.Common
{
    public class ManualPayStationSettings
    {
        public string DeviceId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string TdServerIPAddress { get; set; }
        public string TdServerPort { get; set; }
        public string TdServerUsername { get; set; }
        public string TdServerPassword { get; set; }
        public string VehicleStatusPassword { get; set; }
        public string FourWheelerParkingSpace { get; set; }
        public string TwoWheelerParkingSpace { get; set; }
        public string FourWheelerParkingRate { get; set; }
        public string TwoWheelerParkingRate { get; set; }
        public string LostTicketPenality { get; set; }
    }
}
