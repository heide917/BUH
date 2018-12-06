 using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<DAL.Models.Journal, Domain.Models.Journal>()
                .ReverseMap()
                .ForMember(x => x.Person, y => y.Ignore())
                .ForMember(x => x.Provider, y => y.Ignore())
                .ForMember(x => x.Source, y => y.Ignore())
                .ForMember(x => x.Inventory, y => y.Ignore());
        
        }
    }
}
