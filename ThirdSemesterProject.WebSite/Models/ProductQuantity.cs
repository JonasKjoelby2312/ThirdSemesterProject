using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.WebSite.Models;

public class ProductQuantity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }

    public ProductQuantity(ProductDTO product, int quantity)
    {
        Id = product.ProductId;
        Price = product.SalesPrice;
        Name = product.Name;
        Quantity = quantity;
    }

    public ProductQuantity()
    {
    }

    public decimal GetTotalPrice () 
    { 
        return Price * Quantity; 
    }
}
