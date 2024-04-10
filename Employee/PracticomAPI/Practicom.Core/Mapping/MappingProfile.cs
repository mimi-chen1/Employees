using AutoMapper;
using Practicom.Core.DTOs;
using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core
{
    public class MappingProfile:Profile
    {
      public MappingProfile()
        { 
            CreateMap<Employee,EmployeeDto>().ReverseMap();
              CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<EmployeePosition, EmployeePositionDto>().ReverseMap();
        
        }
    }
}
