using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

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
