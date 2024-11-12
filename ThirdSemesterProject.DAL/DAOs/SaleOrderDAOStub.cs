using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public class SaleOrderDAOStub : IDAO<SaleOrder>
{
    List<SaleOrder> _saleOrders;

    public SaleOrderDAOStub()
    {
        _saleOrders = new List<SaleOrder>();
    }

    public int CreateAsync(SaleOrder entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(SaleOrder entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SaleOrder> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SaleOrder> GetAllClothes()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SaleOrder> GetAllEquipment()
    {
        throw new NotImplementedException();
    }

    public SaleOrder GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(SaleOrder entity)
    {
        throw new NotImplementedException();
    }
}
