namespace ThirdSemesterProject.DAL.Model;

public class SaleOrder
{
    public int SaleOrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public Customer Customer { get; set; }
    public List<OrderLine> OrderLines { get; set; }

    public SaleOrder()
    {
        OrderLines = new List<OrderLine>();
        OrderDate = DateTime.Now;
        Customer = new Customer() { Name = "", Email = "", Password = "", PersonId = 0, PersonType = "", PhoneNO = "", Address = new Address() { City = "", HouseNo = "", RoadName = "", Zip = 0 } };
        //OrderLines = new List<OrderLine>() { new OrderLine { OrderLineId = 1, Product = new Product { ProductId = 1, Color = "", CurrentStock = 10, Description = "", Name = " ", ProductType = "", SalesPrice = 100, Size = "", Weight = 3 }, Quantity = 2, UnitPrice = 100 } };
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
            res += orderLine.Quantity * orderLine.UnitPrice;
        }
        return res;
    }
}