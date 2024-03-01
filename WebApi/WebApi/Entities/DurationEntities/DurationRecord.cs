namespace WebApi.Entities.DurationEntities
{
    /// <summary>
    /// Информация о продолжительности чатов за определённую дату 
    /// </summary>
    public class DurationRecord
    {
        /// <summary>
        /// Продолжительность общения с агентами
        /// </summary>
        public int AgentsChattingDuration { get; set; }
        /// <summary>
        /// Количество чатов
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Продолжительноть чата
        /// </summary>
        public int Duration { get; set; }
    }
}
