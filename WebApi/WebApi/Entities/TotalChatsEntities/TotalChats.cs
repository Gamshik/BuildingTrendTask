using System.Text.Json;

namespace WebApi.Entities.TotalChatsEntities
{
    public class TotalChats
    {
        public int Total { get; set; }
        public Dictionary<DateTime, TotalChatsRecord> Records { get; set; }
        public TotalChats()
        {
            Total = 10399;
            Records = new Dictionary<DateTime, TotalChatsRecord>()
            {
                { DateTime.Parse("2024-01-01"), new TotalChatsRecord() {Total = 760}},
                { DateTime.Parse("2024-01-02"), new TotalChatsRecord() {Total = 819}},
                { DateTime.Parse("2024-01-03"), new TotalChatsRecord() {Total = 815}},
                { DateTime.Parse("2024-01-04"), new TotalChatsRecord() {Total = 806}},
                { DateTime.Parse("2024-01-05"), new TotalChatsRecord() {Total = 721}},
                { DateTime.Parse("2024-01-06"), new TotalChatsRecord() {Total = 735}},
                { DateTime.Parse("2024-01-07"), new TotalChatsRecord() {Total = 742}},
                { DateTime.Parse("2024-01-08"), new TotalChatsRecord() {Total = 839}},
                { DateTime.Parse("2024-01-09"), new TotalChatsRecord() {Total = 766}},
                { DateTime.Parse("2024-01-10"), new TotalChatsRecord() {Total = 752}},
                { DateTime.Parse("2024-01-11"), new TotalChatsRecord() {Total = 807}},
                { DateTime.Parse("2024-01-12"), new TotalChatsRecord() {Total = 866}},
                { DateTime.Parse("2024-01-13"), new TotalChatsRecord() {Total = 895}},
                { DateTime.Parse("2024-01-14"), new TotalChatsRecord() {Total = 76}}
            };
        }
        public string ToJson() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
