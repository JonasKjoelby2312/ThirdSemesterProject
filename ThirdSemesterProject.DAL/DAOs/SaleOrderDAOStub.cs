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

    public int Create(SaleOrder entity)
    {

        var nextAvailableId = _saleOrders.Max(entity => entity.SaleOrderId) + 1;
        entity.SaleOrderId = nextAvailableId;
        _saleOrders.Add(entity);
        return entity.SaleOrderId;

    }

    public bool Delete(SaleOrder entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SaleOrder> GetAll()
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

    public SaleOrder GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(SaleOrder entity)
    {
        throw new NotImplementedException();
    }
}
