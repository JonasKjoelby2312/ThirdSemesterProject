using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebAPI.DTOs;

public class SaleOrderDTO
{
    public int SaleOrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public CustomerDTO CustomerDTO { get; set; }
    public List<OrderLineDTO> OrderLines { get; set; }

    public SaleOrderDTO()
    {
        OrderLines = new List<OrderLineDTO>();
        OrderDate = DateTime.Now;
        CustomerDTO = new CustomerDTO() { PersonId = 0, Name = "", Email = "", PersonType = "", PhoneNO = "", AddressDTO = new AddressDTO() { City = "", HouseNo = "", RoadName = "", Zip = 0 } };
       
    }
}
