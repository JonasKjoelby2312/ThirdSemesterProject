using APIClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient
{
    public interface IAPIClient
    {
        Task<int> CreateProductAsync(Product entity);
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(Product entity);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();







    }
}
