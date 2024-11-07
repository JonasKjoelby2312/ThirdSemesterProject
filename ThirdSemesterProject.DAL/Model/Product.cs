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

    public Product(int productId, string size, int currentStock, string name, string description, double weight) : base(name, description, weight)
    {
        ProductId = productId;
        Size = size;
        CurrentStock = currentStock;
    }

    public override string ToString()
    {
        return $"Product Size: {Size}, product name: {Name}, description: {Description}, weight: {Weight}, stock: {CurrentStock}";
    }


}
