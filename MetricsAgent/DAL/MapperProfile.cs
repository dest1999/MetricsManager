using AutoMapper;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Models.BaseMetricValue, CommonClassesLibrary.BaseMetricDTO>();//перенос Models.BaseMetricValue => CommonClassesLibrary.BaseMetricDTO...
            CreateMap<CommonClassesLibrary.BaseMetricDTO, Models.BaseMetricValue>();//... и обратно
        }
    }
}
