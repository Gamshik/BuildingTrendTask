using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApi.Entities;
using WebApi.Entities.BaseEntities;
using WebApi.Entities.DurationEntities;
using WebApi.Entities.RatingEntities;
using WebApi.Entities.RequestEntities;
using WebApi.Entities.ResponseTimeEntities;
using WebApi.Entities.TagEntities;
using WebApi.Entities.TotalChatsEntities;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public ChatsController()
        {
            _totalChatsReport = new TotalChatsReport();
            _durationReport = new DurationReport();
            _ratingReport = new RatingReport();
            _responseTimeReport = new ResponseTimeReport();
            _tagReport = new TagsReport();
        }

        [HttpGet("total-chats-report")]
        public IActionResult GetTotalChatsRepost([FromQuery] RequestData data)
        {
            var finalTotalChatsReport = _totalChatsReport.GetFinalReport(data.Filters.From, data.Filters.To);

            return Ok(ToJson(finalTotalChatsReport));
        }

        [HttpGet("duration-report")]
        public IActionResult GetDurationReport([FromQuery] RequestData data)
        {
            var finalDurationReport = _durationReport.GetFinalReport(data.Filters.From, data.Filters.To);

            return Ok(ToJson(finalDurationReport));
        }

        [HttpGet("ratings-report")]
        public IActionResult GetRatingsReport([FromQuery] RequestData data)
        {
            var finalRatingsReport = _ratingReport.GetFinalReport(data.Filters.From, data.Filters.To);

            return Ok(ToJson(finalRatingsReport));
        }

        [HttpGet("response-time-report")]
        public IActionResult GetResponseTimeReport([FromQuery] RequestData data)
        {
            var finalResponseTimeReport = _responseTimeReport.GetFinalReport(data.Filters.From, data.Filters.To);

            return Ok(ToJson(finalResponseTimeReport));
        }

        [HttpGet("tags-report")]
        public IActionResult GetTagsReport([FromQuery] RequestData data)
        {
            var finalTagsReport = _tagReport.GetFinalReport(data.Filters.From, data.Filters.To);

            return Ok(ToJson(finalTagsReport));
        }


        /// <summary>
        ///  Метод реализующий сериализацию объекта в JSON
        /// </summary>
        /// <param name="obj">Объект для серилазиации</param>
        /// <returns>Строку представляющую собой JSON</returns>
        private string ToJson(object obj) => JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
    }
}
