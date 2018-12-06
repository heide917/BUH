using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<DAL.Models.Class, Domain.Models.Class>()
                .ReverseMap()
                .ForMember(x => x.Categories, y => y.Ignore());
        }
    }
}
