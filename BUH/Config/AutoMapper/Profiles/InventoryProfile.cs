using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Config.AutoMapper.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<DAL.Models.Inventory, Domain.Models.Inventory>()
                .ReverseMap()
                .ForMember(x => x.Account, y => y.Ignore())
                .ForMember(x => x.Journals, y => y.Ignore())
                .ForMember(x => x.Person, y => y.Ignore())
                .ForMember(x => x.Provider, y => y.Ignore())
                .ForMember(x => x.SubTransactions, y => y.Ignore());
        }
    }
}
