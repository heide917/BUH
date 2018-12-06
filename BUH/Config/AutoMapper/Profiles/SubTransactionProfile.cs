using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Config.AutoMapper.Profiles
{
    public class SubTransactionProfile : Profile
    {
        public SubTransactionProfile()
        {
            CreateMap<DAL.Models.SubTransaction, Domain.Models.SubTransaction>()
                .ReverseMap()
                .ForMember(x => x.Debet, y => y.Ignore())
                .ForMember(x => x.Kredit, y => y.Ignore())
                .ForMember(x => x.Transaction, y => y.Ignore())
                .ForMember(x => x.Inventory, y => y.Ignore());
        }
    }
}
