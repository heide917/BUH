using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BUH.Config.AutoMapper.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<DAL.Models.Transaction, Domain.Models.Transaction>()
                .ReverseMap()
                .ForMember(x => x.User, y => y.Ignore())
                .ForMember(x => x.SubTransactions, y => y.Ignore());
        }
    }
}
