using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public interface ISaleOrderDAO
{
    public Task<List<SaleOrder>> GetAllSaleOrdersByPersonId(int personId);
    Task<IEnumerable<SaleOrder>> GetAllAsync();
    Task<SaleOrder> GetByIdAsync(int id);
    Task<int> CreateAsync(SaleOrder entity);
    Task<bool> Update(SaleOrder entity);
    Task<bool> Delete(SaleOrder entity);
}
