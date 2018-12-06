using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<DAL.Models.Account, Domain.Models.Account>()
                .ForMember(x => x.CategorieName, y => y.MapFrom(z => z.Categorie.Name))
                .ForMember(x => x.ClassName, y => y.MapFrom(z => z.Categorie.Class.Name))
                .ReverseMap()
                .ForMember(x => x.Categorie, y => y.Ignore())
                .ForMember(x => x.SubTransactionsDebet, y => y.Ignore())
                .ForMember(x => x.SubTransactionsKredit, y => y.Ignore())
                .ForMember(x => x.Inventories, y => y.Ignore())
                .ForMember(x => x.Providers, y => y.Ignore());
        }
    }
}
