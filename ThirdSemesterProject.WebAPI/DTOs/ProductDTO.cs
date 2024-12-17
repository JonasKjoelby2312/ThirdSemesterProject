namespace ThirdSemesterProject.WebAPI.DTOs;

public class ProductDTO
{
    #region Properties 
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }
    public string Size { get; set; }
    public int CurrentStock { get; set; }
    public decimal SalesPrice { get; set; }
    public string  Color { get; set; }
    public string ProductType { get; set; }
    #endregion

    public ProductDTO()
    {
    }
}
