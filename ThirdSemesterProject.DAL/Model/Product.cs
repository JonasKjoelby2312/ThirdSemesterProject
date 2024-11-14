using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class Product : Component
{
    public int ProductId { get; set; }
    public string Size { get; set; }
    public int CurrentStock { get; set; }
    //public decimal SalesPrice { get; set; }
    //public string Color { get; set; }
    public string ProductType { get; set; }
    public int Fk_componentId { get; set; }

    //public Product(int productId, string size, int currentStock, /*string color*/ /*decimal salesPrice,*/ string productType, int fk_componentId, string name, string description, decimal weight) : base(name, description, weight)
    //{
    //    ProductId = productId;
    //    Size = size;
    //    CurrentStock = currentStock;
    //    //SalesPrice = salesPrice;
    //    //Color = color;
    //    ProductType = productType;
    //    Fk_componentId = fk_componentId;
    //}
    public override string ToString()
    {
        return $"Product Size: {Size}, product name: {Name}, description: {Description}, weight: {Weight}, stock: {CurrentStock}";
    }
    // , price: {SalesPrice

}
