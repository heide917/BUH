using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Config.AutoMapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<DAL.Models.Person, Domain.Models.Person>()
                .ReverseMap()
                .ForMember(x => x.Inventories, y => y.Ignore())
                .ForMember(x => x.Journals, y => y.Ignore());
        }
    }
}
