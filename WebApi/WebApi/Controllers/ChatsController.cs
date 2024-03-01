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
        /// ����������� � ������� ���������������� ���������� ���������� ������
        /// </summary>
        /// <param name="mapper">���� ������</param>
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

            // �������������� ���������� � ������� ��� �������� ������ ���
            var reportDto = _mapper.Map<ReportDto<TotalChatsRecord>>(finalTotalChatsReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("duration-report")]
        public IActionResult GetDurationReport([FromQuery] RequestData data)
        {
            var finalDurationReport = _durationReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // �������������� ���������� � ������� ��� �������� ������ ���
            var reportDto = _mapper.Map<ReportDto<DurationRecord>>(finalDurationReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("ratings-report")]
        public IActionResult GetRatingsReport([FromQuery] RequestData data)
        {
            var finalRatingsReport = _ratingReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // �������������� ���������� � ������� ��� �������� ������ ���
            var reportDto = _mapper.Map<ReportDto<RatingRecord>>(finalRatingsReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("response-time-report")]
        public IActionResult GetResponseTimeReport([FromQuery] RequestData data)
        {
            var finalResponseTimeReport = _responseTimeReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // �������������� ���������� � ������� ��� �������� ������ ���
            var reportDto = _mapper.Map<ReportDto<ResponseTimeRecord>>(finalResponseTimeReport);

            return Ok(ToJson(reportDto));
        }

        [HttpGet("tags-report")]
        public IActionResult GetTagsReport([FromQuery] RequestData data)
        {
            var finalTagsReport = _tagReport.GetFinalReport(data.Filters.From, data.Filters.To);

            // �������������� ���������� � ������� ��� �������� ������ ���
            var reportDto = _mapper.Map<ReportDto<dynamic>>(finalTagsReport);

            return Ok(ToJson(reportDto));
        }

        /// <summary>
        /// ����� ����������� ������������ ������� � JSON
        /// </summary>
        /// <typeparam name="TValue">��� ������� � �������</typeparam>
        /// <param name="report">������ ��� ������������</param>
        /// <returns>������ �������������� ����� JSON</returns>
        private string ToJson<TValue>(ReportDto<TValue> report) => JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
    }
}
