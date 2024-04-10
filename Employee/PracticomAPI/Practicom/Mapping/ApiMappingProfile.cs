using AutoMapper;
using Practicom.API.Models;
using Practicom.Core.Entites;

namespace Practicom.API.Mapping
{
    public class ApiMappingProfile:Profile
    {
       public ApiMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<PositionPostModel, Position>();
            CreateMap<EmployeePositionPostModel, EmployeePosition>();
        }


    }
}
