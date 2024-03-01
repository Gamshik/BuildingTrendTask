namespace WebApi.Entities.RequestEntities
{
    /// <summary>
    /// Структура запроса
    /// </summary>
    public class RequestData
    {
        /// <summary>
        /// Распространение
        /// </summary>
        public string Distribution { get; set; }
        /// <summary>
        /// Фильтр даты
        /// </summary>
        public Filters Filters { get; set; }
    }
}
