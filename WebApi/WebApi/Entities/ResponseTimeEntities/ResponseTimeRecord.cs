namespace WebApi.Entities.ResponseTimeEntities
{
    /// <summary>
    /// Данные о времени ответа
    /// </summary>
    public class ResponseTimeRecord
    {
        /// <summary>
        /// Количество ответов
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Время ответа
        /// </summary>
        public double ResponseTime { get; set; }
    }
}
