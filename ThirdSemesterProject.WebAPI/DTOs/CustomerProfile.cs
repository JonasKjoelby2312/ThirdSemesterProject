using AutoMapper;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebAPI.DTOs;

public class CustomerProfile : Profile
{

    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
