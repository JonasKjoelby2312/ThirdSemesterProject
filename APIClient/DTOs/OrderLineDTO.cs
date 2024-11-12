using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

public class OrderLineDTO
{
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
}
