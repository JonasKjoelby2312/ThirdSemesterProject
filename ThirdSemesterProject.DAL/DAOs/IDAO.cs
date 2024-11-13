using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.DAOs;

public interface IDAO<T>
{
    IEnumerable<T> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<int> CreateAsync(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);

}
