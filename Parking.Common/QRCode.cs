using System;
using System.Drawing;
using System.Linq;
using QRCoder;

namespace Parking.Common
{
    public static class QRCode
    {
        public static string GenerateQRCode(string validationNumber, string vehicleNumber, int vehicleType, string entryTime)
        {
            return Security.Encrypt(validationNumber + "_" + vehicleNumber + "_" + vehicleType + "_" + entryTime);
        }

        public static Bitmap GetQRCodeImage(string code)
        {
            var writer = new ZXing.QrCode.QRCodeWriter();            
            var encodedString = writer.encode(code, ZXing.BarcodeFormat.QR_CODE, 4, 4);            
            var qrCodeWriter = new ZXing.BarcodeWriter();
            return qrCodeWriter.Write(encodedString);
        }
    }
}
