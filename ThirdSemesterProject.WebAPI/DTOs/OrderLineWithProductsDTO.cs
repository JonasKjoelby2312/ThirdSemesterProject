namespace ThirdSemesterProject.WebAPI.DTOs;

public class OrderLineWithProductsDTO
{
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }

    public OrderLineWithProductsDTO()
    {
    }
}
