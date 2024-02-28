using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Entities.DurationEntities;
using WebApi.Entities.RatingEntities;
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

        public ChatsController()
        {
            _totalChatsReport = new TotalChatsReport();
            _durationReport = new DurationReport();
            _ratingReport = new RatingReport();
            _responseTimeReport = new ResponseTimeReport();
            _tagReport = new TagsReport();
        }

        [HttpGet("total-chats-report")]
        public IActionResult GetTotalChatsRepost()
        {
            return Ok(_totalChatsReport.ToJson());
        }

        [HttpGet("duration-report")]
        public IActionResult GetDurationReport()
        {
            return Ok(_durationReport.ToJson());
        }

        [HttpGet("ratings-report")]
        public IActionResult GetRatingsReport()
        {
            return Ok(_ratingReport.ToJson());
        }

        [HttpGet("response-time-report")]
        public IActionResult GetResponseTimeReport()
        {
            return Ok(_responseTimeReport.ToJson());
        }

        [HttpGet("tags-report")]
        public IActionResult GetTagsReport()
        {
            return Ok(_tagReport.ToJson());
        }
    }
}
