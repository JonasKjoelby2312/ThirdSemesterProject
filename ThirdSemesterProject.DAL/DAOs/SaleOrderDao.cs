using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

//SaleOrderDao = SaleOrderDAO?

/// <summary>
/// Implementation of the ISaleOrderDAO interface
/// </summary>
public class SaleOrderDAO : BaseDAO, ISaleOrderDAO
{
    private readonly string INSERT_SALEORDER = "INSERT INTO sale_order(order_date, total, fk_customer_id) VALUES (@OrderDate, @Total, @PersonId) SELECT CAST(SCOPE_IDENTITY() AS INT);"; //TODO customer fk?
    private readonly string INSERT_ORDERLINES = "INSERT INTO order_line (quantity, unit_price, fk_sale_order_id, fk_product_id) VALUES (@Quantity, @UnitPrice, @SaleOrderId, @FKProductId);";
    private readonly string GET_STOCK_BY_PRODUCT_ID = "SELECT current_Stock from product WHERE product_id = @productId;";
    private readonly string UPDATE_CURRENT_STOCK = "UPDATE product set current_stock = current_stock - @quantity where product_id = @productId;";
    private readonly string GET_ALL_SALEORDERS_BY_PERSONID = "SELECT sale_order_id as SaleOrderId, order_date as OrderDate, total as Total, fk_customer_id as CustomerId from sale_order where fk_customer_id = @person_id";
    private readonly string GET_ORDERLINES_BY_SALEORDERID = "SELECT p.name AS Name, ol.quantity AS Quantity, ol.unit_price AS UnitPrice FROM order_line ol JOIN product p ON ol.fk_product_id = p.product_id WHERE ol.fk_sale_order_id = @saleOrderId;";

    public SaleOrderDAO(string connectionstring) : base(connectionstring)
    {
    }

    //This method is used for getting all saleOrder with the orderLines and products
    //The method takes an personId in the params. 
    //The method returns a List with saleOrders with orderLines and products. 
    public async Task<List<SaleOrder>> GetAllSaleOrdersByPersonId(int personId) // returnerer en liste med saleorders, med en liste af orderlines, der IKKE har produkt objekter på sig!!
    {
        using var connection = CreateConnection();
        connection.Open();
        try
        {
            var saleOrders = await connection.QueryAsync<SaleOrder>(GET_ALL_SALEORDERS_BY_PERSONID, new { person_id = personId });
            foreach (var so in saleOrders)
            {
                using var orderLinesAndProducts = await connection.QueryMultipleAsync(GET_ORDERLINES_BY_SALEORDERID, new { SaleOrderId = so.SaleOrderId });

                var orderLinesWithProducts = orderLinesAndProducts.Read<OrderLineWithProducts>().ToList();
                foreach (var line in orderLinesWithProducts)
                {
                    Product p = new Product() { Name = line.Name };
                    OrderLine ol = new OrderLine() { Quantity = line.Quantity, UnitPrice = line.UnitPrice, Product = p };
                    so.AddOrderLineToSaleOrder(ol);
                }

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

    //This method is used for getting all saleOrders by personID
    //The method takes a personId in the params. 
    //The method returns a IEnumerable<SaleOrder>
    public async Task<IEnumerable<SaleOrder>> GetAllSaleOrders(int personId)
    {
        using var connection = CreateConnection();
        connection.Open();
        try
        {
            var saleOrders = await connection.QueryAsync<SaleOrder>(GET_ALL_SALEORDERS_BY_PERSONID, new { person_id = personId });
            connection.Close();
            return saleOrders;
        }
        catch (Exception ex) 
        {

            throw new Exception("No SaleOrders exsist");
        }
    }
 

    //lav sammen evt. i forhold samtigheds problem
    /// <summary>
    /// Used for creating a saleOrder.
    /// </summary>
    /// <param name="entity">SaleOrder object??</param>
    /// <returns>the newly created saleOrderID.</returns>
    /// <exception cref="Exception">?</exception>
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
            int saleOrderId = await connection.ExecuteScalarAsync<int>(INSERT_SALEORDER, new { OrderDate = entity.OrderDate, Total = entity.Total, PersonId = entity.Customer.PersonId }, 
            transaction);

            foreach (OrderLine orderLine in entity.OrderLines)
            {
                int orderLineId = await connection.ExecuteScalarAsync<int>(INSERT_ORDERLINES, new { quantity = orderLine.Quantity,
                unitPrice = orderLine.UnitPrice, saleOrderId = saleOrderId, FKProductId = orderLine.Product.ProductId }, transaction);
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


    //Arbejder videre i morgen
    public async Task<IEnumerable<OrderLineWithProducts>> GetAllOrderLinesWithProductsBySaleOrderId(int id)
    {
        using var connection = CreateConnection();
        connection.Open();
        List<OrderLineWithProducts> listOfOrderLinesWithProducts = new List<OrderLineWithProducts>();
        try
        {
            var orderLinesWithProducts = await connection.QueryAsync<OrderLineWithProducts>(GET_ORDERLINES_BY_SALEORDERID, new { SaleOrderId = id } );
            foreach (var line in orderLinesWithProducts)
            {
                OrderLineWithProducts currOrderLineWithProduct = new OrderLineWithProducts();
                currOrderLineWithProduct.Name = line.Name;
                currOrderLineWithProduct.UnitPrice = line.UnitPrice;
                currOrderLineWithProduct.Quantity = line.Quantity;
                listOfOrderLinesWithProducts.Add(currOrderLineWithProduct);
            }
            return listOfOrderLinesWithProducts;
        }
        catch (Exception ex)
        {

            throw new Exception("Could not get orderlines and products exception was: ", ex) ;
        }
        
    }


    //slettes?
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
