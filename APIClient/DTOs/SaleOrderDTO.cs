using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

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
        CustomerDTO = new CustomerDTO() { PersonId = 1, Name = "", Email = "", Password = "", PersonType = "", PhoneNO = "", AddressDTO = new AddressDTO() { City = "Aalborg", HouseNo = "23, 4 TV", RoadName = "Rømøgade", Zip = 9000 } };
    }
}
