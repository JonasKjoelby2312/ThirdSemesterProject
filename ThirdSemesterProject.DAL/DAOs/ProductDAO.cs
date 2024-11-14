using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public class ProductDAO : BaseDAO, IDAOAsync<Product>
{
    private readonly string GET_AÆÆ  = "\tWITH LatestSalesPrice AS (\r\n    SELECT fk_product_id, value, creation_date\r\n\tFROM sales_price\r\n    WHERE creation_date = (SELECT MAX(creation_date) FROM sales_price WHERE fk_product_id = sales_price.fk_product_id))\r\nSELECT component_id, name, description, weight, size, color, current_stock as currentStock, product_id as productId, value AS salesPrice\r\nFROM component RIGHT OUTER JOIN product ON component.component_id = product.fk_component_id RIGHT OUTER JOIN LatestSalesPrice ON product.product_id = LatestSalesPrice.fk_product_id;";
    private readonly string GET_ALL_PRODUCTS = "SELECT component_id, name, description, weight, product_id, size, color, current_stock from component RIGHT OUTER JOIN product on fk_component_id = component_id;";
    private readonly string INSERT_PRODUCT = "INSERT INTO product values size = @size, color = @color, current_stock = @current_stock;";
    private readonly string INSERT_COMPONENT = "INSERT INTO component name = @name, description = @description, weight = @weight;";
    private readonly string SELECT_PRODUCT_BY_ID = "WITH LatestSalesPrice AS (    SELECT fk_product_id, value, creation_date FROM sales_price  WHERE creation_date = (SELECT MAX(creation_date) FROM sales_price WHERE fk_product_id = sales_price.fk_product_id)) SELECT component_id, name, description, weight, size, color, current_stock as currentStock, product_id as productId, value AS salesPrice FROM component RIGHT OUTER JOIN product ON component.component_id = product.fk_component_id RIGHT OUTER JOIN LatestSalesPrice ON product.product_id = LatestSalesPrice.fk_product_id where product_id = @productId;";


    public ProductDAO(string connectionString) : base(connectionString)
    {
    }



    public async Task<int> CreateAsync(Product entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            int componentId = await connection.ExecuteScalarAsync<int>(INSERT_COMPONENT, entity, transaction);

            int productId = await connection.ExecuteScalarAsync<int>(INSERT_PRODUCT, entity, transaction);

            return componentId;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Error inserting new product: '{ex.Message}'.", ex);
        }
    }

    public async Task<bool> Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var connection = CreateConnection();
        var products = await connection.QueryAsync<Product>(GET_AÆÆ);
        return products;
    }

    public async Task<IEnumerable<Product>> GetAllClothes()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllEquipment()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();
        var product = await connection.QuerySingleAsync<Product>(SELECT_PRODUCT_BY_ID);
        return product;
    }

    public async Task<bool> Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
