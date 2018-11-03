using System.IO.Ports;

namespace Parking.Interfaces
{
    public interface ISerialPortCommunicate
    {
        bool Connect(string portName, int baudRate, Parity parity, int databits, StopBits stopBits);
    }
}
