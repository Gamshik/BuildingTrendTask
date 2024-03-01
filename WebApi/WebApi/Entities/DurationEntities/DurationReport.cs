using WebApi.Entities.BaseEntities;

namespace WebApi.Entities.DurationEntities
{
    /// <summary>
    /// Отчёт о продолжительности чатов
    /// </summary>
    public class DurationReport : ReportBase<DurationRecord>
    {
        /// <summary>
        /// Заполнение данных
        /// </summary>
        public DurationReport()
        {
            Total = 10399;
            Records = new Dictionary<DateTime, DurationRecord>()
            {
                { DateTime.Parse("2024-01-01"), new DurationRecord() {AgentsChattingDuration = 407, Count = 760, Duration = 590}},
                { DateTime.Parse("2024-01-02"), new DurationRecord() {AgentsChattingDuration = 394, Count = 819, Duration = 560}},
                { DateTime.Parse("2024-01-03"), new DurationRecord() {AgentsChattingDuration = 396, Count = 815, Duration = 556}},
                { DateTime.Parse("2024-01-04"), new DurationRecord() {AgentsChattingDuration = 444, Count = 806, Duration = 593}},
                { DateTime.Parse("2024-01-05"), new DurationRecord() {AgentsChattingDuration = 420, Count = 721, Duration = 565}},
                { DateTime.Parse("2024-01-06"), new DurationRecord() {AgentsChattingDuration = 381, Count = 735, Duration = 531}},
                { DateTime.Parse("2024-01-07"), new DurationRecord() {AgentsChattingDuration = 385, Count = 742, Duration = 556}},
                { DateTime.Parse("2024-01-08"), new DurationRecord() {AgentsChattingDuration = 461, Count = 839, Duration = 633}},
                { DateTime.Parse("2024-01-09"), new DurationRecord() {AgentsChattingDuration = 470, Count = 766, Duration = 629}},
                { DateTime.Parse("2024-01-10"), new DurationRecord() {AgentsChattingDuration = 385, Count = 752, Duration = 532}},
                { DateTime.Parse("2024-01-11"), new DurationRecord() {AgentsChattingDuration = 438, Count = 807, Duration = 591}},
                { DateTime.Parse("2024-01-12"), new DurationRecord() {AgentsChattingDuration = 388, Count = 866, Duration = 528}},
                { DateTime.Parse("2024-01-13"), new DurationRecord() {AgentsChattingDuration = 456, Count = 895, Duration = 612}},
                { DateTime.Parse("2024-01-14"), new DurationRecord() {AgentsChattingDuration = 410, Count = 76, Duration = 535}}
            };
        }
    }
}
