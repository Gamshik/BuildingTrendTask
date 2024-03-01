namespace WebApi.Entities.RequestEntities
{
    /// <summary>
    /// Фильтр даты
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// От какого дня
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// До какого дня
        /// </summary>
        public DateTime To { get; set; }
    }
}
