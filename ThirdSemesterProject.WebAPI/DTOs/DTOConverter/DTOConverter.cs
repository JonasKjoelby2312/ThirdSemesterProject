using System.Net.WebSockets;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

public static class DTOConverter
{
    public static SaleOrder FromDTO(this SaleOrderDTO saleOrderDTOToConvert )
    {
        var saleOrder = new SaleOrder();
        saleOrderDTOToConvert.CustomerDTO.CopyPropertiesTo(saleOrder.Customer);
        saleOrderDTOToConvert.CopyPropertiesTo(saleOrder);
        //saleOrder.OrderLines = new List<OrderLine>();
        foreach (OrderLineDTO item in saleOrderDTOToConvert.OrderLines)
        {
            Product product = item.ProductDTO.FromDTO();
            saleOrder.AddOrderLineToSaleOrder(item.FromDTO(product));
        }
        return saleOrder;
    }

    public static OrderLine FromDTO(this OrderLineDTO orderLineDTOToConvert, Product product)
    {
        var orderLine = new OrderLine();
        orderLineDTOToConvert.CopyPropertiesTo(orderLine); 
        orderLine.Product = product;
        return orderLine;
    }

    public static Product FromDTO(this ProductDTO productDTOToConvert)
    {
        var product = new Product();
        productDTOToConvert.CopyPropertiesTo(product);
        return product;
    }

    public static Customer FromDTO(this CustomerDTO customerDTOToConvert)
    {
        var customer = new Customer();
        customerDTOToConvert.CopyPropertiesTo(customer);
        return customer;
    }

    public static SaleOrderDTO ToDTO(this SaleOrder saleOrderToConvert)
    {
        var saleOrderDTO = new SaleOrderDTO();
        saleOrderToConvert.CopyPropertiesTo(saleOrderDTO);
        return saleOrderDTO;

    }
    public static IEnumerable<SaleOrderDTO> ToDTOs(this IEnumerable<SaleOrder> saleOrderToConvert)
    {
        foreach (var saleOrder in saleOrderToConvert)
        {
            yield return saleOrder.ToDTO();
        }

    }

    private static OrderLineWithProductsDTO ToDTO(this OrderLineWithProducts orderLineWithProducts)
    {
        var orderLineWithProductDTO = new OrderLineWithProductsDTO();
        orderLineWithProducts.CopyPropertiesTo(orderLineWithProductDTO);
        return orderLineWithProductDTO;

    }

    public static IEnumerable<OrderLineWithProductsDTO> ToDTOs(this IEnumerable<OrderLineWithProducts> orderLineWithProducts)
    {   

        foreach (var olwp in orderLineWithProducts)
        {
            yield return olwp.ToDTO();
        }
        

    }
}
