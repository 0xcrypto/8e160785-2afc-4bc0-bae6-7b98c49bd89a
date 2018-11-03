using Parking.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Parking.Common;
using Parking.Common.Model;
using System.Data.SqlClient;

namespace Parking.Database.CommandFactory
{
    public class ParkingDatabaseFactory : IParkingDatabaseFactory
    {
        private readonly ISqlDataAccess sqlDataAccess;
        private readonly Dictionary<string, string> queries = new Dictionary<string, string>();
        private const string MasterId = "4D587294-4DC1-421A-8FB5-D5DE9FB0ED4A";

        public ParkingDatabaseFactory()
        {
            sqlDataAccess = new SqlDataAccess();
            queries.Add("SelectMasterSettings", @"SELECT  [CompanyName],
                                                          [ParkingPlaceCode],
                                                          [ParkingPlaceName],
                                                          [TwoWheelerParkingRatePerHour],
                                                          [FourWheelerParkingRatePerHour],
                                                          [LostTicketPenality]
                                                FROM [tbl_master] 
                                                WHERE [Id] = '{0}'");

            queries.Add("UpdateMasterSettings", @"  UPDATE [tbl_master]
                                                    SET [CompanyName] = '{0}', 
                                                        [ParkingPlaceCode] = '{1}', 
                                                        [ParkingPlaceName] = '{2}', 
                                                        [TwoWheelerParkingRatePerHour] = '{3}', 
                                                        [FourWheelerParkingRatePerHour] = '{4}', 
                                                        [LostTicketPenality] = '{5}', 
                                                    WHERE [Id] = '{6}'");

            queries.Add("InsertVehicleEntry", @"INSERT INTO [tbl_parking]
                                                            ([TDClientDeviceId],
                                                             [TicketNumber],
                                                             [ValidationNumber],
                                                             [QRCode],
                                                             [VehicleNumber],
                                                             [VehicleType],
                                                             [EntryTime],
                                                             [DriverImage],
                                                             [VehicleImage],
                                                             [IsParkingEntryDetailsUploadedToServer],
                                                             [IsParkingExitDetailsUploadedToServer])
                                                            
                                                              
                                                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' as Image,'{8}','{9}','{10}')");

            queries.Add("GetVehicleEntry", @"Select * from [tbl_parking] where [VehicleNumber] = '{0}'");


            queries.Add("GetUniqueCode", @"select cast((Abs(Checksum(NewId()))%10) as varchar(1)) +  char(ascii('a') + (Abs(Checksum(NewId()))%25)) + 
                                                char(ascii('A')+(Abs(Checksum(NewId()))%25)) + left(newid(),5) as UniqueCode");

            //MPS QUERIES
            queries.Add("InsertLostTicket", @"INSERT INTO [tbl_LostTicket]
                                                             ([Name],
                                                             [VehicleNumber],
                                                             [DocumentType],
                                                             [DocumentNumber],
                                                             [DocumentImage])
                                                VALUES ('{0}','{1}','{2}','{3}','{4}')");

            queries.Add("GetShiftData", @"select count(*) as RecordCount, sum([ParkingCharge]) as TotalCollection from [tbl_parking]
                                                where ExitTime is not null and  ParkingCharge is not null  and ExitTime > '{0}'");

            queries.Add("GetVehicleEntryWebServerUploadData", @"SELECT [Id], [TDClientDeviceId], [TicketNumber], [ValidationNumber], [VehicleNumber], 
                            [VehicleType], [EntryTime] FROM [tbl_parking] WHERE [IsParkingEntryDetailsUploadedToServer] = 0");

            queries.Add("UpdateVehicleEntryWebServerUploadStatus", @"UPDATE [tbl_parking] SET [IsParkingEntryDetailsUploadedToServer] = 1 WHERE [Id] = '{0}'");

            queries.Add("GetVehicleExitWebServerUploadData", @"SELECT [Id], [MPSDeviceId], [TicketNumber], [ExitTime], [ParkingDuration], [ParkingCharge], 
                            [PenalityCharge], [TotalPaidAmount] FROM [tbl_parking] WHERE [IsParkingEntryDetailsUploadedToServer] = 1 AND [IsParkingExitDetailsUploadedToServer] = 0 ");

            queries.Add("UpdateVehicleExitWebServerUploadStatus", @"UPDATE [tbl_parking] SET [IsParkingExitDetailsUploadedToServer] = 1 WHERE [Id] = '{0}'");
        }

        public void UpdateMasterSettings(string companyName,
            string parkingPlaceCode,
            string parkingPlaceName,
            string twoWheelerParkingRatePerHour,
            string fourWheelerParkingRatePerHour,
            string lostTicketPenality)
        {
            try
            {
                var query = string.Format(queries["UpdateMasterSettings"], companyName, parkingPlaceCode, parkingPlaceName,
                                          twoWheelerParkingRatePerHour, fourWheelerParkingRatePerHour, lostTicketPenality, MasterId);
                sqlDataAccess.ExecuteNonQuery(query);

            }
            catch (Exception exception)
            {
                FileLogger.Log($"TDClient Master settings could not be updated successfully to database as : {exception.Message}");
                throw;
            }
        }

        public DataRow GetMasterSettings()
        {
            try
            {
                var query = string.Format(queries["SelectMasterSettings"], MasterId);

                var sqlCommand = sqlDataAccess.GetCommand(query);

                var result = sqlDataAccess.Execute(sqlCommand);

                return result.Rows[0];
            }
            catch (Exception exception)
            {
                FileLogger.Log($"TDClient Master settings could not be loaded successfully from database as : {exception.Message}");
                throw;
            }

        }

        public void SaveVehicleEntry(string deviceId, Ticket ticket)
        {
            try
            {
                var insertQuery = string.Format(queries["InsertVehicleEntry"], deviceId,
                    ticket.TicketNumber, ticket.ValidationNumber, ticket.QRCode, ticket.VehicleNumber, (int)ticket.VehicleType, ticket.EntryTime, ticket.DriverImage, ticket.VehicleImage, 0, 0);
                sqlDataAccess.ExecuteNonQuery(insertQuery);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Ticket Information Could not be saved in database as : {exception.Message}");
                throw;
            }
        }

        public string GetUniqueCode()
        {
            var sqlCommand = sqlDataAccess.GetCommand(queries["GetUniqueCode"]);
            var dataRow = sqlDataAccess.Execute(sqlCommand).Rows[0];
            return dataRow[0].ToString();
        }

        public DataTable GetVehicleEntry(string vehicleNumber)
        {
            try
            {
                var getQuery = string.Format(queries["GetVehicleEntry"], vehicleNumber);
                var sqlCommand = sqlDataAccess.GetCommand(getQuery);

                var result = sqlDataAccess.Execute(sqlCommand);

                return result;
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Vehicle's parking information could not be find in database as : {exception.Message}");
                throw;
            }
        }

        public void SaveLostTicketInfo(string name, string vehicleNumber, byte documentType, string documentNumber)
        {
            try
            {
                var insertQuery = string.Format(queries["InsertLostTicket"], name,
                    vehicleNumber, documentType, documentNumber, null);
                sqlDataAccess.ExecuteNonQuery(insertQuery);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Lost Ticket Information Could not be saved in database as : {exception.Message}");
                throw;
            }
        }

        public DataTable GetPendingVehicles()
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "Get_PendingVehicles";
                var result = sqlDataAccess.ExecuteDataReturningStoredProcedure(cmd);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tuple<int, int> GetShiftData(string entryTime)
        {
            try
            {
                var getQuery = string.Format(queries["GetShiftData"], entryTime);
                var result = sqlDataAccess.Execute(getQuery);
                int count = 0;
                int collection = 0;
                if (result.Rows.Count > 0)
                {

                    count = (int)result.Rows[0]["RecordCount"];
                    collection = (object)result.Rows[0]["TotalCollection"] == DBNull.Value ? 0 :(int)result.Rows[0]["TotalCollection"];

                }
                return Tuple.Create(count, collection);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Shift Data Could not be retrieved from database as : {exception.Message}");
                throw;
            }
        }

        public DataTable GetVehicleEntryDataForWebServerUpload()
        {
            try
            {
                var query = string.Format(queries["GetVehicleEntryWebServerUploadData"]);

                var sqlCommand = sqlDataAccess.GetCommand(query);

                return sqlDataAccess.Execute(sqlCommand);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Problem fetching vehicle entry information for uploading on Web Server as : {exception.Message}");
                throw;
            }

        }

        public void UpdateVehicleEntryWebServerUploadStatus(string parkingId)
        {
            try
            {
                var query = string.Format(queries["UpdateVehicleEntryWebServerUploadStatus"], parkingId);
                sqlDataAccess.ExecuteNonQuery(query);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Problem updating vehicle entry web server upload status for parking = {parkingId} as : {exception.Message}");
                throw;
            }
        }

        public DataTable GetVehicleExitDataForWebServerUpload()
        {
            try
            {
                var query = string.Format(queries["GetVehicleExitWebServerUploadData"]);

                var sqlCommand = sqlDataAccess.GetCommand(query);

                return sqlDataAccess.Execute(sqlCommand);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Problem fetching vehicle exit information for uploading on Web Server as : {exception.Message}");
                throw;
            }

        }

        public void UpdateVehicleExitWebServerUploadStatus(string parkingId)
        {
            try
            {
                var query = string.Format(queries["UpdateVehicleExitWebServerUploadStatus"], parkingId);
                sqlDataAccess.ExecuteNonQuery(query);
            }
            catch (Exception exception)
            {
                FileLogger.Log($"Problem updating vehicle exit web server upload status for parking = {parkingId} as : {exception.Message}");
                throw;
            }
        }

    }
}
