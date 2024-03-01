using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApi.Entities.DataTransferObjects;
using WebApi.Entities.DurationEntities;
using WebApi.Entities.RatingEntities;
using WebApi.Entities.RequestEntities;
using WebApi.Entities.ResponseTimeEntities;
using WebApi.Entities.TagEntities;
using WebApi.Entities.TotalChatsEntities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatsController : ControllerBase
    {
        private TotalChatsReport _totalChatsReport;
        private DurationReport _durationReport;
        private RatingReport _ratingReport;
        private ResponseTimeReport _responseTimeReport;
        private TagsReport _tagReport;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор в котором инициализируются переменные содержащие данные
        /// </summary>
        /// <param name="mapper">Авто маппер</param>
        public ChatsController(IMapper mapper)
        {
            _totalChatsReport = new TotalChatsReport();
            _durationReport = new DurationReport();
            _ratingReport = new RatingReport();
            _responseTimeReport = new ResponseTimeReport();
            _tagReport = new TagsReport();
            _mapper = mapper;
        }

        [HttpGet("total-chats-report")]
        public IActionResult GetTotalChatsRepost([FromQuery] RequestData data)
        {
            var finalTotalChatsReport = _totalChatsReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // Преобразование переменной в удобный для передачи данных вид
            var reportDto = _mapper.Map<ReportDto<TotalChatsRecord>>(finalTotalChatsReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("duration-report")]
        public IActionResult GetDurationReport([FromQuery] RequestData data)
        {
            var finalDurationReport = _durationReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // Преобразование переменной в удобный для передачи данных вид
            var reportDto = _mapper.Map<ReportDto<DurationRecord>>(finalDurationReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("ratings-report")]
        public IActionResult GetRatingsReport([FromQuery] RequestData data)
        {
            var finalRatingsReport = _ratingReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // Преобразование переменной в удобный для передачи данных вид
            var reportDto = _mapper.Map<ReportDto<RatingRecord>>(finalRatingsReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("response-time-report")]
        public IActionResult GetResponseTimeReport([FromQuery] RequestData data)
        {
            var finalResponseTimeReport = _responseTimeReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // Преобразование переменной в удобный для передачи данных вид
            var reportDto = _mapper.Map<ReportDto<ResponseTimeRecord>>(finalResponseTimeReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("tags-report")]
        public IActionResult GetTagsReport([FromQuery] RequestData data)
        {
            var finalTagsReport = _tagReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // Преобразование переменной в удобный для передачи данных вид
            var reportDto = _mapper.Map<ReportDto<dynamic>>(finalTagsReport);

            return Ok(ToJson(reportDto));
        }

        /// <summary>
        /// Метод реализующий сериализацию объекта в JSON
        /// </summary>
        /// <typeparam name="TValue">Тип объекта в словаре</typeparam>
        /// <param name="report">Объект для серилазиации</param>
        /// <returns>Строку представляющую собой JSON</returns>
        private string ToJson<TValue>(ReportDto<TValue> report) => JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
    }
}
