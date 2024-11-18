using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

public class OrderLineDTO
{
    public int OrderLineId { get; set; }
    public ProductDTO Product {  get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
