using Parking.Common;
using Parking.Common.Enums;
using Parking.Common.Model;
using Parking.Database.CommandFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Parking.Utilities
{
    public class OfflineRecordProcessor
    {
        private const string queuerFileName = "OfflineRecords.txt";
        private static string filePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), queuerFileName);

        private readonly static ParkingDatabaseFactory parkingDatabaseFactory = new ParkingDatabaseFactory();
        private readonly static object FileLock = new object();

        public static void Queue(object Object)
        {
            lock (FileLock)
            {
                Ticket ticket = (Ticket)Object;
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    try
                    {
                        var stream = new MemoryStream();
                        var driverImage = ticket.DriverImage;
                        driverImage.Save(stream, driverImage.RawFormat);
                        var driverImageBytes = stream.ToArray();

                        var vehicleImage = ticket.VehicleImage;
                        driverImage.Save(stream, driverImage.RawFormat);
                        var vehicleImageBytes = stream.ToArray();

                        streamWriter.Write($"{ticket.TicketNumber}(TP){ticket.ValidationNumber}(TP){ticket.QRCode}(TP){ticket.VehicleNumber}(TP){(int)ticket.VehicleType}(TP){ticket.EntryTime}(TP){ Convert.ToBase64String(driverImageBytes)}(TP){ Convert.ToBase64String(vehicleImageBytes)}(TICKET){Environment.NewLine}");
                        streamWriter.Close();

                    }
                    catch (Exception exception)
                    {
                        FileLogger.Log($"Ticket Queuing Failed for Vehicle number {ticket.VehicleNumber} of type {ticket.VehicleType} which entered at {ticket.EntryTime} as : {exception.Message} ");
                    }
                }
            }
        }

        public static void Dequeue(object Object)
        {
            lock (FileLock)
            {
                var ticketList = new List<Ticket>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var data = reader.ReadToEnd();
                    reader.Close();
                    var allRecords = data.Split(new string[] { "(TICKET)" }, StringSplitOptions.None);

                    //Return if there are no records to be synced
                    if (!(allRecords.Length > 1)) return;

                    //Remove all records from file after reading them
                    File.WriteAllText(filePath, string.Empty);

                    var configurationSettings = ConfigurationReader.GetConfigurationSettings();

                    for (int i = 0; i < allRecords.Length - 1; i++)
                    {
                        var ticketData = allRecords[i].Split(new string[] { "(TP)" }, StringSplitOptions.None);

                        //Draw driver image from Base64 string
                        byte[] driverImageBytes = Convert.FromBase64String(ticketData[6]);
                        MemoryStream ms1 = new MemoryStream(driverImageBytes, 0, driverImageBytes.Length);
                        ms1.Write(driverImageBytes, 0, driverImageBytes.Length);
                        Image driverImage = Image.FromStream(ms1, true);

                        //Draw vehicle image from Base64 string
                        byte[] vehicleImageBytes = Convert.FromBase64String(ticketData[7]);
                        MemoryStream ms2 = new MemoryStream(vehicleImageBytes, 0, vehicleImageBytes.Length);
                        ms2.Write(vehicleImageBytes, 0, vehicleImageBytes.Length);
                        Image vehicleImage = Image.FromStream(ms2, true);

                        var ticket = new Ticket()
                        {
                            TicketNumber = ticketData[0],
                            ValidationNumber = ticketData[1],
                            QRCode = ticketData[2],
                            VehicleNumber = ticketData[3],
                            VehicleType = (VehicleType)int.Parse(ticketData[4]),
                            EntryTime = ticketData[5],
                            DriverImage = (Bitmap)driverImage,
                            VehicleImage = (Bitmap)vehicleImage
                        };
                        ticketList.Add(ticket);
                    }

                    foreach (var ticket in ticketList)
                    {
                        try
                        {
                            parkingDatabaseFactory.SaveVehicleEntry(configurationSettings.TDClientDeviceId, ticket);
                        }
                        catch (Exception)
                        {
                            //Queue all tickets again in case of network Failure
                            Queue(ticket);
                        }
                    }
                }
            }
        }
    }
}
