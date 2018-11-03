using System;
using System.Linq;

namespace Parking.Common
{
    public class UniqueCode
    {
        public string GenerateCode()
        {
            var random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var ticketNumber = new string(Enumerable.Repeat(chars, 10)
                                              .Select(s => s[random.Next(s.Length)]).ToArray());
            return ticketNumber;
        }
    }
}
