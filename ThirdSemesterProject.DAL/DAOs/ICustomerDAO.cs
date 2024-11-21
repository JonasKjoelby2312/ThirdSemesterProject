using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public interface ICustomerDAO
{
    Task<int> CreateAsync(Customer entity, string password);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
    Task<Customer> GetByEmailAsync(string email);
    Task<bool> UpdateAsync(Customer entity);
    Task<bool> DeleteAsync(int id);
    Task<int> LoginAsync(string email, string password);
}
