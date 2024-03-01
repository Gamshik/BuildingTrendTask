namespace WebApi.Entities.DataTransferObjects
{
    public class ReportDto<TValue>
    {
        public int Total { get; set; }
        public Dictionary<string, TValue> Records { get; set; }
    }
}
