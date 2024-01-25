using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Solid.Core.DTOs;
using Solid.Core.Enteties;

namespace Solid.Core
{
    public class MappingProFile:Profile
    {
        public MappingProFile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<OffiicalDto, Official>().ReverseMap();
            CreateMap<TurnDto, Turn>().ReverseMap();
        }
    }
}
