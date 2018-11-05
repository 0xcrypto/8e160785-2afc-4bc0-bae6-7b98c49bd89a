using System.IO.Ports;

namespace Parking.Common
{
    public interface ISerialPortCommunicate
    {
        bool Connect(string portName, int baudRate, Parity parity, int databits, StopBits stopBits);
    }
}
