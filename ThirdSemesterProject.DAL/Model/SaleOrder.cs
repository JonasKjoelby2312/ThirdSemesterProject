namespace ThirdSemesterProject.DAL.Model;

public class SaleOrder 
{
    public DateTime OrderDate { get; set; }
    public decimal Total {  get; set; }
    public Customer Customer {  get; set; }

    public List<OrderLine> OrderLines { get; }
    /*  public string Address { get; set; }*/

    public SaleOrder(Customer customer)
    {
        OrderDate = DateTime.Now;
        Customer = customer;
        OrderLines = new List<OrderLine>();
    }

    public bool AddOrderLineToSaleOrder(OrderLine orderLine)
    {
        if (orderLine != null)
        {
            OrderLines.Add(orderLine);
            return true;
        }
        return false;
    }

    public bool RemoveOrderLinesFromSaleOrder(OrderLine orderLine)
    { 
        if (orderLine != null)
        {
            OrderLines.Remove(orderLine);
            return true;
        }
         return false;
    }

    public decimal CalculateTotal()
    {
        decimal res = 0;
        foreach (OrderLine orderLine in OrderLines)
        {
            res += orderLine.SubTotal;
        }
        return res;
    }

    
}