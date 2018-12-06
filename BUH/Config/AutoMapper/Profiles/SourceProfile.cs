using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class SourceProfile : Profile
    {
        public SourceProfile()
        {
            CreateMap<DAL.Models.Source, Domain.Models.Source>()
                .ReverseMap()
                .ForMember(x => x.Journals, y => y.Ignore());
        }
    }
}
