using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }
    public string Size { get; set; }
    public int CurrentStock { get; set; }
    public decimal SalesPrice { get; set; }
    public string Color { get; set; }
    public string ProductType { get; set; }

    public Product()
    {

    }
    public override string ToString()
    {
        return $"Product Size: {Size}, product name: {Name}, description: {Description}, weight: {Weight}, stock: {CurrentStock}";
    }
    // , price: {SalesPrice

}
