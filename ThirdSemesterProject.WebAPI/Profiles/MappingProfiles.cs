using AutoMapper;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.DTOs;

namespace ThirdSemesterProject.WebAPI.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressDTO)) ;
        CreateMap<Address, AddressDTO>().ReverseMap();  
        
        
    }
}
