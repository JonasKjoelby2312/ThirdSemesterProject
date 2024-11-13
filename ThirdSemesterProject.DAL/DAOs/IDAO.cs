using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.DAOs;

public interface IDAO<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    int Create(T entity);
    bool Update(T entity);
    bool Delete(T entity);

}
