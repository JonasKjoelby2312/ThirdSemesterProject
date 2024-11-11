using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.DAOs;

public interface IDAO<T>
{
    IEnumerable<T> GetAllAsync();
    IEnumerable<T> GetAllEquipment();
    IEnumerable<T> GetAllClothes();

    T GetByIdAsync(int id);
    int CreateAsync(T entity);
    bool Update(T entity);
    bool Delete(T entity);

}
