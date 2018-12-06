using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<DAL.Models.Contract, Domain.Models.Contract>()
                .ReverseMap()
                .ForMember(x => x.Provider, y => y.Ignore());
        }
    }
}
