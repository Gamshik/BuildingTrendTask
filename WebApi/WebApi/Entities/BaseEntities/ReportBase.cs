using System.Text.Json;

namespace WebApi.Entities.BaseEntities
{
    public class ReportBase<TValue>
    {
        public int Total { get; set; }
        public Dictionary<DateTime, TValue> Records { get; set; }
        
        /// <summary>
        /// Метод выбирающий данные за определённый промежуток времени
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
