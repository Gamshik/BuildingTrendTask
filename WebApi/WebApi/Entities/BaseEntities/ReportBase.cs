using System.Text.Json;

namespace WebApi.Entities.BaseEntities
{
    public abstract class BaseReport<TValue>
    {
        public int Total;
        public Dictionary<DateTime, TValue> Records;
        
        /// <summary>
        /// Метод выбирающий данные за определённый промежуток времени
        /// </summary>
        /// <param name="from">Начальная дата</param>
        /// <param name="to">Конечная дата</param>
        /// <returns>Итоговый отчёт</returns>
        public object GetFinalReport(DateTime from, DateTime to)
        {
            return new
            {
                Total,
                Records = Records.Where(record => record.Key >= from && record.Key <= to).ToDictionary(key => key.Key, value => value.Value)
            };
        }
    }
}
