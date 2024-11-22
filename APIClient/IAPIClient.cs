using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.APIClient;

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









}
