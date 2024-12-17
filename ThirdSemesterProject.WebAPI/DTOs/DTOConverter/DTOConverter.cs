using System.Net.WebSockets;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

/// <summary>
/// Provides extension methods to convert between DTO (Data Transfer Objects).
/// </summary>
public static class DTOConverter
{

    /// <summary>
    /// Converts a <see cref="SaleOrderDTO"/> to a <see cref="SaleOrder"/>.
    /// </summary>
    /// <param name="saleOrderDTOToConvert">The DTO to convert.</param>
    /// <returns>A <see cref="SaleOrder"/></returns>
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

    /// <summary>
    /// Converts an <see cref="OrderLineDTO"/> to an <see cref="OrderLine"/> with a given product.
    /// </summary>
    /// <param name="orderLineDTOToConvert">The DTO to convert.</param>
    /// <param name="product">The associated <see cref="Product"/>.</param>
    /// <returns>An <see cref="OrderLine"/></returns>
    public static OrderLine FromDTO(this OrderLineDTO orderLineDTOToConvert, Product product)
    {
        var orderLine = new OrderLine();
        orderLineDTOToConvert.CopyPropertiesTo(orderLine); 
        orderLine.Product = product;
        return orderLine;
    }

    /// <summary>
    /// Converts a <see cref="ProductDTO"/> to a <see cref="Product"/>.
    /// </summary>
    /// <param name="productDTOToConvert">The DTO to convert.</param>
    /// <returns>A <see cref="Product"/></returns>
    public static Product FromDTO(this ProductDTO productDTOToConvert)
    {
        var product = new Product();
        productDTOToConvert.CopyPropertiesTo(product);
        return product;
    }

    /// <summary>
    /// Converts a <see cref="CustomerDTO"/> to a <see cref="Customer"/>.
    /// </summary>
    /// <param name="customerDTOToConvert">The DTO to convert.</param>
    /// <returns>A <see cref="Customer"/></returns>
    public static Customer FromDTO(this CustomerDTO customerDTOToConvert)
    {
        var customer = new Customer();
        customerDTOToConvert.CopyPropertiesTo(customer);
        return customer;
    }

    /// <summary>
    /// Converts a <see cref="SaleOrder"/>to a <see cref="SaleOrderDTO"/>.
    /// </summary>
    /// <param name="saleOrderToConvert">to convert.</param>
    /// <returns>A <see cref="SaleOrderDTO"/>.</returns>
    public static SaleOrderDTO ToDTO(this SaleOrder saleOrderToConvert)
    {
        var saleOrderDTO = new SaleOrderDTO();
        saleOrderToConvert.CopyPropertiesTo(saleOrderDTO);
        return saleOrderDTO;
    }

    /// <summary>
    /// Converts an enumerable of <see cref="SaleOrder"/> to a collection of <see cref="SaleOrderDTO"/>s.
    /// </summary>
    /// <param name="saleOrderToConvert">The enumerable to convert.</param>
    /// <returns>An enumerable of <see cref="SaleOrderDTO"/>s.</returns>
    public static IEnumerable<SaleOrderDTO> ToDTOs(this IEnumerable<SaleOrder> saleOrderToConvert)
    {
        foreach (var saleOrder in saleOrderToConvert)
        {
            yield return saleOrder.ToDTO();
        }
    }

    /// <summary>
    /// Converts an <see cref="OrderLineWithProducts"/> to an <see cref="OrderLineWithProductsDTO"/>.
    /// </summary>
    /// <param name="orderLineWithProducts"> to convert.</param>
    /// <returns>An <see cref="OrderLineWithProductsDTO"/>.</returns>
    private static OrderLineWithProductsDTO ToDTO(this OrderLineWithProducts orderLineWithProducts)
    {
        var orderLineWithProductDTO = new OrderLineWithProductsDTO();
        orderLineWithProducts.CopyPropertiesTo(orderLineWithProductDTO);
        return orderLineWithProductDTO;
    }

    /// <summary>
    /// Converts an enumerable of <see cref="OrderLineWithProducts"/> to a collection of <see cref="OrderLineWithProductsDTO"/>s.
    /// </summary>
    /// <param name="orderLineWithProducts">The enumerable to convert.</param>
    /// <returns>An enumerable of <see cref="OrderLineWithProductsDTO"/>s.</returns>
    public static IEnumerable<OrderLineWithProductsDTO> ToDTOs(this IEnumerable<OrderLineWithProducts> orderLineWithProducts)
    {   
        foreach (var olwp in orderLineWithProducts)
        {
            yield return olwp.ToDTO();
        }
    }
}
