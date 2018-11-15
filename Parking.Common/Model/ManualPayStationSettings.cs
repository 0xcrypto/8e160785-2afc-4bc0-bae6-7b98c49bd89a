namespace Parking.Common
{
    public class ManualPayStationSettings
    {
        public string DeviceId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string TdServerIPAddress { get; set; }
        public int TdServerPort { get; set; }
        public string TdServerUsername { get; set; }
        public string TdServerPassword { get; set; }
        public string VehicleStatusPassword { get; set; }
        public int FourWheelerParkingSpace { get; set; }
        public int TwoWheelerParkingSpace { get; set; }
        public float FourWheelerParkingRate { get; set; }
        public float TwoWheelerParkingRate { get; set; }
        public float LostTicketPenality { get; set; }
    }
}
