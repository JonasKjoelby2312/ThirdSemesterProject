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
    public decimal SubTotal { get; set; }
}
