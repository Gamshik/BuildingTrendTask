using System.Text.Json;

namespace WebApi.Entities.RatingEntities
{
    public class RatingReport
    {
        public int Total { get; set; }
        public Dictionary<DateTime, RatingRecord> Records { get; set; }

        public RatingReport()
        {
            Total = 10339;
            Records = new Dictionary<DateTime, RatingRecord>()
            {
                {DateTime.Parse("2024-01-01"), new RatingRecord() { Bad = 19, Chats = 760, Good = 78 } },
                {DateTime.Parse("2024-01-02"), new RatingRecord() { Bad = 19, Chats = 819, Good = 78 } },
                {DateTime.Parse("2024-01-03"), new RatingRecord() { Bad = 28, Chats = 815, Good = 68 } },
                {DateTime.Parse("2024-01-04"), new RatingRecord() { Bad = 25, Chats = 806, Good = 88 } },
                {DateTime.Parse("2024-01-05"), new RatingRecord() { Bad = 16, Chats = 721, Good = 81 } },
                {DateTime.Parse("2024-01-06"), new RatingRecord() { Bad = 12, Chats = 735, Good = 72 } },
                {DateTime.Parse("2024-01-07"), new RatingRecord() { Bad = 16, Chats = 742, Good = 81 } },
                {DateTime.Parse("2024-01-08"), new RatingRecord() { Bad = 21, Chats = 839, Good = 97 } },
                {DateTime.Parse("2024-01-09"), new RatingRecord() { Bad = 26, Chats = 766, Good = 54 } },
                {DateTime.Parse("2024-01-10"), new RatingRecord() { Bad = 26, Chats = 752, Good = 56 } },
                {DateTime.Parse("2024-01-11"), new RatingRecord() { Bad = 24, Chats = 807, Good = 73 } },
                {DateTime.Parse("2024-01-12"), new RatingRecord() { Bad = 26, Chats = 866, Good = 90 } },
                {DateTime.Parse("2024-01-13"), new RatingRecord() { Bad = 21, Chats = 895, Good = 71 } },
                {DateTime.Parse("2024-01-14"), new RatingRecord() { Bad = 76, Good = 11 } }
            };
        }

        public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
