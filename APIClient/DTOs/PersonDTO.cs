using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

public class PersonDTO
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
    
    public string Email { get; set; }
    public string? PhoneNO { get; set; }
    public string PersonType { get; set; }
    public string Password { get; set; }
    public AddressDTO AddressDTO { get; set; }

    public PersonDTO()
    {
        PersonType = "Person";
        AddressDTO = new AddressDTO(); //{ RoadName = "Rømøgade", City = "Aalborg", HouseNo = "32, 5 TV", Zip = 9000};
    }

}
