namespace WebApi.Entities.BaseEntities
{
    /// <summary>
    /// Структура отчёта
    /// </summary>
    /// <typeparam name="TValue">Тип объекта с данными за определённую дату</typeparam>
    public class ReportBase<TValue>
    {
        /// <summary>
        /// Итоговое значение
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Данные за определённую дату
        /// </summary>
        public Dictionary<DateTime, TValue> Records { get; set; }

        /// <summary>
        /// Получение данных за определённый промежуток времени
        /// </summary>
        /// <param name="from">Начальная дата</param>
        /// <param name="to">Конечная дата</param>
        /// <returns>Итоговый отчёт</returns>
        public ReportBase<TValue> GetFinalReport(DateTime from, DateTime to)
        {
            return new ReportBase<TValue>
            {
                Total = Total,
                Records = Records.Where(record => record.Key >= from && record.Key <= to).ToDictionary(key => key.Key, value => value.Value)
            };

        }
    }
}
