using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class OrderLine
{
    public int OrderLineId { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; }
    public decimal UnitPrice { get; set; }

    public OrderLine(Product product, int quantity)
    {
        Quantity = quantity;
        Product = product;
    }
}
