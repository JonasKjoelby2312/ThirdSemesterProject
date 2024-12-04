using System.ComponentModel.DataAnnotations;

namespace ThirdSemesterProject.WebAPI.DTOs;

public class PersonDTO
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
    
    public string Email { get; set; }
    public string? PhoneNO { get; set; }
    public string PersonType { get; set; }
    
    public string Password { get; set; }
    public AddressDTO AddressDTO { get; set; }

}

