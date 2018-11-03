using Parking.Common.Model;
using System;
using System.Data;

namespace Parking.Interfaces
{
    public interface IParkingDatabaseFactory
    {
        void UpdateMasterSettings(string companyName,
            string parkingPlaceCode,
            string parkingPlaceName,
            string twoWheelerParkingRatePerHour,
            string fourWheelerParkingRatePerHour,
            string lostTicketPenality);

        DataRow GetMasterSettings();

        void SaveVehicleEntry(string deviceId, Ticket ticket);

        DataTable GetVehicleEntry(string vehicleNumber);

        string GetUniqueCode();

        void SaveLostTicketInfo(string name, string vehicleNumber, byte documentType, string documentNumber);

        DataTable GetPendingVehicles();

        Tuple<int, int> GetShiftData(string entryTime);
    }
}