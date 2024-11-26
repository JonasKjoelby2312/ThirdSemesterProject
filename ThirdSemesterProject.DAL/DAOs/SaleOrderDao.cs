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
    private readonly string INSERT_SALEORDER = "INSERT INTO sale_order(order_date, total, fk_customer_id) VALUES (@OrderDate, @Total, @PersonId) SELECT CAST(SCOPE_IDENTITY() AS INT);"; //TODO customer fk?
    private readonly string INSERT_ORDERLINES = "INSERT INTO order_line (quantity, unit_price, fk_sale_order_id, fk_product_id) VALUES (@Quantity, @UnitPrice, @SaleOrderId, @FKProductId);";
    private readonly string GET_STOCK_BY_PRODUCT_ID = "SELECT current_Stock from product WHERE product_id = @productId;";
    private readonly string UPDATE_CURRENT_STOCK = "UPDATE product set current_stock = current_stock - @quantity where product_id = @productId;";
    private readonly string GET_ALL_SALEORDERS_BY_PERSONID = "SELECT sale_order_id as SaleOrderId, order_date as OrderDate, total as Total, fk_customer_id as CustomerId from sale_order where fk_customer_id = @person_id";
    private readonly string GET_ORDERLINES_BY_SALEORDERID = "SELECT order_line_id as OrderLineId, quantity as Quantity, unit_price as UnitPrice, fk_sale_order_id as SaleOrderId, fk_product_id as ProductId from order_line where fk_sale_order_id = @sale_order_id";
    public SaleOrderDAO(string connectionstring) : base(connectionstring)
    {
    }

    public async Task<List<SaleOrder>> GetAllSaleOrdersByPersonId(int personId) // returnerer en liste med saleorders, med en liste af orderlines, der IKKE har produkt objekter på sig!!
    {
        using var connection = CreateConnection();
        connection.Open();
        try
        {
            var saleOrders = await connection.QueryAsync<SaleOrder>(GET_ALL_SALEORDERS_BY_PERSONID, new { person_id = personId });
            foreach (var so in saleOrders)
            {
                var orderLines = await connection.QueryAsync<OrderLine>(GET_ORDERLINES_BY_SALEORDERID, new { sale_order_id = so.SaleOrderId });
                so.OrderLines = orderLines.ToList();
            }
            connection.Close();
            return saleOrders.ToList();
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception($"Could not get SaleOrders and Orderlines. Message was: {ex.Message}", ex);
        }
    }

    public async Task<int> CreateAsync(SaleOrder entity)
    {
        using var connection = CreateConnection();
        foreach (OrderLine orderLine in entity.OrderLines)
        {
            int currentStock = await connection.ExecuteScalarAsync<int>(GET_STOCK_BY_PRODUCT_ID, new { productId = orderLine.Product.ProductId });
            if (currentStock < orderLine.Quantity)
            {
                throw new Exception("CurrentStock is less than orderLine.Quantity");
            }
        }
        connection.Open();

        IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            entity.Total = entity.CalculateTotal();
            int saleOrderId = await connection.ExecuteScalarAsync<int>(INSERT_SALEORDER, new { OrderDate = entity.OrderDate, Total = entity.Total, PersonId = entity.Customer.PersonId }, transaction);

            foreach (OrderLine orderLine in entity.OrderLines)
            {
                int orderLineId = await connection.ExecuteScalarAsync<int>(INSERT_ORDERLINES, new { quantity = orderLine.Quantity, unitPrice = orderLine.UnitPrice, saleOrderId = saleOrderId, FKProductId = orderLine.Product.ProductId }, transaction);
                orderLine.OrderLineId = orderLineId;
                await connection.ExecuteAsync(UPDATE_CURRENT_STOCK, new { quantity = orderLine.Quantity, productId = orderLine.Product.ProductId }, transaction);
                int currentStock = await connection.ExecuteScalarAsync<int>(GET_STOCK_BY_PRODUCT_ID, new { productId = orderLine.Product.ProductId }, transaction);
                if (currentStock < 0)
                {
                    throw new Exception($"CurrentStock: {currentStock}, requested stock: {orderLine.Quantity}");
                }
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
