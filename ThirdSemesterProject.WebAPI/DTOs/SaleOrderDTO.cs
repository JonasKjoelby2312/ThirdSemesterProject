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
        CustomerDTO = new CustomerDTO() { PersonId = 1, Name = "John", Email = "", PasswordHash = "", PersonType = "", PhoneNO = "" };
       // OrderLines = new List<OrderLineDTO>() { new OrderLineDTO { OrderLineId = 1, ProductDTO =  new ProductDTO { ProductId = 1, CurrentStock = 2, Description = "", Name = "", ProductType = "", SalesPrice = 23, Size = "" }, Quantity = 1, UnitPrice = 23}
        //};
    }
}
