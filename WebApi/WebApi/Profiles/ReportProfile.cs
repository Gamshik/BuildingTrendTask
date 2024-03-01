using AutoMapper;
using WebApi.Entities.BaseEntities;
using WebApi.Entities.DataTransferObjects;
using WebApi.Entities.DurationEntities;
using WebApi.Entities.RatingEntities;
using WebApi.Entities.ResponseTimeEntities;
using WebApi.Entities.TotalChatsEntities;

namespace WebApi.Profiles
{
    /// <summary>
    /// Правила для мапинга объектов
    /// </summary>
    public class ReportProfile : Profile
    {
        /// <summary>
        /// Инициализация правил
        /// </summary>
        public ReportProfile()
        {
            CreateMap<ReportBase<DurationRecord>, ReportDto<DurationRecord>>().ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records.ToDictionary(record => record.Key.ToString("yyyy-MM-dd"), record => record.Value)));
            CreateMap<ReportBase<RatingRecord>, ReportDto<RatingRecord>>().ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records.ToDictionary(record => record.Key.ToString("yyyy-MM-dd"), record => record.Value)));
            CreateMap<ReportBase<ResponseTimeRecord>, ReportDto<ResponseTimeRecord>>().ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records.ToDictionary(record => record.Key.ToString("yyyy-MM-dd"), record => record.Value)));
            CreateMap<ReportBase<dynamic>, ReportDto<dynamic>>().ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records.ToDictionary(record => record.Key.ToString("yyyy-MM-dd"), record => record.Value)));
            CreateMap<ReportBase<TotalChatsRecord>, ReportDto<TotalChatsRecord>>().ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records.ToDictionary(record => record.Key.ToString("yyyy-MM-dd"), record => record.Value)));
        }
    }
}
