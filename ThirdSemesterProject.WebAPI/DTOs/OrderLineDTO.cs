namespace ThirdSemesterProject.WebAPI.DTOs;

public class OrderLineDTO
{
    public int OrderLineId { get; set; }
    public ProductDTO ProductDTO { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

