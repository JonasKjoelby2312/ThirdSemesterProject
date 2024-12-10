using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.APIClient;

/// <summary>
/// A interface with methods for the APIClient which defines the operations it can use.
/// </summary>
public interface IAPIClient
{
    Task<int> CreateProductAsync(ProductDTO entity);
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task<bool> UpdateProductAsync(ProductDTO entity);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<int> CreateSaleOrderAsync(SaleOrderDTO entity);
    Task<int> LoginAsync(CustomerDTO loginInfo);
    Task<CustomerDTO> GetCustomerByIdAsync(int userId);
    Task<int> CreateCustomerAsync(CustomerDTO customerDTO);
    Task<IEnumerable<SaleOrderDTO>> GetAllSaleOrdersByPersonIdAsync(int id);
    Task<IEnumerable<OrderLineWithProductsDTO>> GetAllOrderLinesWithProductsBySaleOrderIdAsync(int id);


}
