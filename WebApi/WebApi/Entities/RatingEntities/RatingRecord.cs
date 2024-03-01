namespace WebApi.Entities.RatingEntities
{
    /// <summary>
    /// Отчёт о рейтинге
    /// </summary>
    public class RatingRecord
    {
        /// <summary>
        /// Количество плохих оценок
        /// </summary>
        public int Bad { get; set; }
        /// <summary>
        /// Количество чатов
        /// </summary>
        public int Chats { get; set; }
        /// <summary>
        /// Количество хороших оценок
        /// </summary>
        public int Good { get; set; }
    }
}
