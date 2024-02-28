using System.Text.Json;

namespace WebApi.Entities.ResponseTimeEntities
{
    public class ResponseTimeReport
    {
        public int Total { get; set; }
        public Dictionary<DateTime, ResponseTimeRecord> Record { get; set; }

        public ResponseTimeReport()
        {
            Total = 7949;
            Record = new Dictionary<DateTime, ResponseTimeRecord>()
            {
                { DateTime.Parse("2024-01-01"), new ResponseTimeRecord() { Count = 583, ResponseTime = 51.06d } },
                { DateTime.Parse("2024-01-02"), new ResponseTimeRecord() { Count = 637, ResponseTime = 47.69d } },
                { DateTime.Parse("2024-01-03"), new ResponseTimeRecord() { Count = 624, ResponseTime = 47.55d } },
                { DateTime.Parse("2024-01-04"), new ResponseTimeRecord() { Count = 626, ResponseTime = 47.53d } },
                { DateTime.Parse("2024-01-05"), new ResponseTimeRecord() { Count = 555, ResponseTime = 48.09d } },
                { DateTime.Parse("2024-01-06"), new ResponseTimeRecord() { Count = 558, ResponseTime = 44.11d } },
                { DateTime.Parse("2024-01-07"), new ResponseTimeRecord() { Count = 552, ResponseTime = 44.55d } },
                { DateTime.Parse("2024-01-08"), new ResponseTimeRecord() { Count = 677, ResponseTime = 53.59d } },
                { DateTime.Parse("2024-01-09"), new ResponseTimeRecord() { Count = 588, ResponseTime = 53.29d } },
                { DateTime.Parse("2024-01-10"), new ResponseTimeRecord() { Count = 582, ResponseTime = 45.97d } },
                { DateTime.Parse("2024-01-11"), new ResponseTimeRecord() { Count = 633, ResponseTime = 48.63d } },
                { DateTime.Parse("2024-01-12"), new ResponseTimeRecord() { Count = 618, ResponseTime = 47.21d } },
                { DateTime.Parse("2024-01-13"), new ResponseTimeRecord() { Count = 662, ResponseTime = 56d } },
                { DateTime.Parse("2024-01-14"), new ResponseTimeRecord() { Count = 54, ResponseTime = 48.41d } }
            };
        }

        public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
