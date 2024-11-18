using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

public class SaleOrderDTO
{
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public CustomerDTO Customer { get; set; }
    public List<OrderLineDTO> OrderLines { get; }
}
