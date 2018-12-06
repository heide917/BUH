using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Config.AutoMapper.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<DAL.Models.Provider, Domain.Models.Provider>()
                .ReverseMap()
                .ForMember(x => x.Account, y => y.Ignore())
                .ForMember(x => x.Contracts, y => y.Ignore())
                .ForMember(x => x.Inventories, y => y.Ignore())
                .ForMember(x => x.Journals, y => y.Ignore());
        }
    }
}
