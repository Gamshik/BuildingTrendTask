namespace WebApi.Entities.DataTransferObjects
{
    /// <summary>
    /// Data transfer object класс для передачи данных на фронт
    /// </summary>
    /// <typeparam name="TValue">Тип объекта с данными за определённую дату</typeparam>
    public class ReportDto<TValue>
    {
        /// <summary>
        /// Итоговое значение
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Данные за определённую дату
        /// </summary>
        public Dictionary<string, TValue> Records { get; set; }
    }
}
