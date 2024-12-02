using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.VisualBasic;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

public class ProductDAO : BaseDAO, IDAOAsync<Product>
{
    private readonly string GET_PRODUCT_WITH_NEWEST_SALES_PRICE = "WITH LatestSalesPrice AS (SELECT fk_product_id, value, creation_date FROM sales_price sp WHERE sales_price_id = (SELECT TOP 1 sales_price_id FROM sales_price WHERE fk_product_id = sp.fk_product_id ORDER BY creation_date DESC, sales_price_id DESC)) SELECT product.product_id AS productId, product.name, product.description, product.weight, product.size, product.color, product.current_stock AS currentStock, LatestSalesPrice.value AS salesPrice, product.product_type AS productType FROM product LEFT JOIN LatestSalesPrice ON product.product_id = LatestSalesPrice.fk_product_id;";
    private readonly string GET_ALL_PRODUCTS = "SELECT product_id, name, description, weight, size, color, current_stock, product_type from product;";
    private readonly string INSERT_PRODUCT = "INSERT INTO product(name, description, weight, size, color, current_stock, product_type) values (@name, @description, @weight, @size, @color, @currentStock, @productType) SELECT CAST(SCOPE_IDENTITY() AS INT)";
    private readonly string SELECT_PRODUCT_BY_ID = "WITH LatestSalesPrice AS (SELECT fk_product_id, value, creation_date FROM sales_price sp WHERE sales_price_id = (SELECT TOP 1 sales_price_id FROM sales_price WHERE fk_product_id = sp.fk_product_id ORDER BY creation_date DESC, sales_price_id DESC)) SELECT product.product_id AS productId, product.name, product.description, product.weight, product.size, product.color, product.current_stock AS currentStock, LatestSalesPrice.value AS salesPrice, product.product_type AS productType FROM product full outer JOIN LatestSalesPrice ON product.product_id = LatestSalesPrice.fk_product_id where product_id = @productId;";
    private readonly string INSERT_SALES_PRICE = "insert into sales_price (creation_date, [value], fk_product_id) VALUES (@creationDate, @value, @fkProductId)";

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
            int productId = await connection.ExecuteScalarAsync<int>(INSERT_PRODUCT, entity, transaction);
            await connection.ExecuteAsync(INSERT_SALES_PRICE, new { value = entity.SalesPrice, creationDate = DateTime.Now, fkProductId = productId }, transaction);

            transaction.Commit();
            return productId;
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
        var products = await connection.QueryAsync<Product>(GET_PRODUCT_WITH_NEWEST_SALES_PRICE);
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
        var product = await connection.QuerySingleAsync<Product>(SELECT_PRODUCT_BY_ID, new {productId = id});
        return product; 
    }

    public async Task<bool> Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
