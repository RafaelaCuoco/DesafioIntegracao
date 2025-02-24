using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationApp.Services
{
    public class LegacyFileReader
    {
        public IEnumerable<string[]> ReadLines(Stream stream)
        {
            using var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                yield return new[]
                {
                line.Substring(0, 10).TrimStart('0'),   // userId
                line.Substring(10, 45).Trim(),          // userName
                line.Substring(55, 10).TrimStart('0'),  // orderId
                line.Substring(65, 10).TrimStart('0'),  // productId
                line.Substring(75, 12),                 // value
                line.Substring(87, 8)                   // date
            };
            }
        }
    }
}
