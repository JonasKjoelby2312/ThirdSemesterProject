﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public interface ISaleOrderDAO
{
    Task<List<SaleOrder>> GetAllSaleOrdersByPersonId(int personId);
    Task<IEnumerable<SaleOrder>> GetAllAsync();
    Task<SaleOrder> GetByIdAsync(int id);
    Task<int> CreateSaleOrderAsync(SaleOrder entity);
    Task<bool> Update(SaleOrder entity);
    Task<bool> Delete(SaleOrder entity);
    Task<IEnumerable<SaleOrder>> GetAllSaleOrders(int id);
    Task<IEnumerable<OrderLineWithProducts>> GetAllOrderLinesWithProductsBySaleOrderId(int id);
}
