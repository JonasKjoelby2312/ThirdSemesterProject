using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs
{
    public interface IProductDAO
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> CreateAsync(Product entity);
        Task<bool> UpdateAsync(Product entity);
        Task<bool> DeleteAsync(Product entity);
        Task<IEnumerable<Product>> FindProductsByPartOfNameAsync(string givenPartOfName);
    }
}
