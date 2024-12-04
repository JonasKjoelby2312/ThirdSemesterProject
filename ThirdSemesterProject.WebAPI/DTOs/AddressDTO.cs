namespace ThirdSemesterProject.WebAPI.DTOs;

public class AddressDTO
{
    public string RoadName { get; set; }
    public string HouseNo { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }

    public AddressDTO()
    {
    }
}