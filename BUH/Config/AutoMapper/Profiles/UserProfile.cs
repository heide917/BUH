using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Config.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DAL.Models.User, Domain.Models.User>()
                .ReverseMap()
                .ForMember(x => x.Transactions, y => y.Ignore());
        }
    }
}
