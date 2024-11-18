using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public class SaleOrderDAO : BaseDAO, IDAOAsync<SaleOrder>
{
    private readonly string INSERT_SALEORDER = "INSERT INTO saleOrder VALUES(order_date = @OrderDate, total = @Total);"; //TODO customer fk?
    private readonly string INSERT_ORDERLINES = "INSERT INTO orderLine VALUES(quantity = @Quantity, unit_price = @UnitPrice, fk_sale_order_id = @FKSaleOrderId, fk_product_id = @FKProductId);";
    private readonly string GET_STOCK_BY_PRODUCT_ID = "SELECT current_Stock from product WHERE product_id = @productId;";
    private readonly string UPDATE_CURRENT_STOCK = "UPDATE product set current_stock = current_stock - @quantity where product_id = @productId;";
    public SaleOrderDAO(string connectionstring) : base(connectionstring)
    {
    }

    public async Task<int> CreateAsync(SaleOrder entity)
    {
        using var connection = CreateConnection();
        foreach (OrderLine orderLine in entity.OrderLines) 
        {
            int currentStock = await connection.ExecuteAsync(GET_STOCK_BY_PRODUCT_ID);
            if (currentStock < orderLine.Quantity)
            {
                throw new Exception("CurrentStock is less than orderLine.Quantity");
            }
        }
        connection.Open();

        IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            int saleOrderId = await connection.ExecuteScalarAsync<int>(INSERT_SALEORDER, entity, transaction);

            foreach (OrderLine orderLine in entity.OrderLines)
            {
                int orderLineId = await connection.ExecuteScalarAsync<int>(INSERT_ORDERLINES, new { quantity = orderLine.Quantity, unit_price = orderLine.UnitPrice, fk_sale_order_id = saleOrderId, fk_product_id = orderLine.Product.ProductId}, transaction);
                orderLine.OrderLineId = orderLineId;
                await connection.ExecuteAsync(UPDATE_CURRENT_STOCK, new { quantity = orderLine.Quantity, productId = orderLine.Product.ProductId }, transaction);
            }

            transaction.Commit();
            return saleOrderId;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Error: Could not persist SaleOrder: {entity} in database. Message was: {ex.Message}", ex);
        }
    }

    public Task<bool> Delete(SaleOrder entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SaleOrder>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SaleOrder> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(SaleOrder entity)
    {
        throw new NotImplementedException();
    }
}
