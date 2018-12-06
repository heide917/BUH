using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class CategorieProfile : Profile
    {
        public CategorieProfile()
        {
            CreateMap<DAL.Models.Categorie, Domain.Models.Categorie>()
                .ReverseMap()
                .ForMember(x => x.Accounts, y => y.Ignore())
                .ForMember(x => x.Class, y => y.Ignore());
        }
    }
}
