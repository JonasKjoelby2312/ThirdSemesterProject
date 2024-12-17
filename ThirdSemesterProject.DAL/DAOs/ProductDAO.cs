using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.VisualBasic;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;

/// <summary>
/// Implementation of the IProductDAO interface
/// </summary>
public class ProductDAO : BaseDAO, IProductDAO
{
    private readonly string GET_PRODUCT_WITH_NEWEST_SALES_PRICE = "WITH LatestSalesPrice AS (SELECT fk_product_id, value, creation_date FROM sales_price sp WHERE sales_price_id = (SELECT TOP 1 sales_price_id FROM sales_price WHERE fk_product_id = sp.fk_product_id ORDER BY creation_date DESC, sales_price_id DESC)) SELECT product.product_id AS productId, product.name, product.description, product.weight, product.size, product.color, product.current_stock AS currentStock, LatestSalesPrice.value AS salesPrice, product.product_type AS productType FROM product LEFT JOIN LatestSalesPrice ON product.product_id = LatestSalesPrice.fk_product_id;";
    private readonly string GET_ALL_PRODUCTS = "SELECT product_id, name, description, weight, size, color, current_stock, product_type from product;";
    private readonly string INSERT_PRODUCT = "INSERT INTO product(name, description, weight, size, color, current_stock, product_type) values (@name, @description, @weight, @size, @color, @currentStock, @productType) SELECT CAST(SCOPE_IDENTITY() AS INT)";
    private readonly string SELECT_PRODUCT_BY_ID = "WITH LatestSalesPrice AS (SELECT fk_product_id, value, creation_date FROM sales_price sp WHERE sales_price_id = (SELECT TOP 1 sales_price_id FROM sales_price WHERE fk_product_id = sp.fk_product_id ORDER BY creation_date DESC, sales_price_id DESC)) SELECT product.product_id AS productId, product.name, product.description, product.weight, product.size, product.color, product.current_stock AS currentStock, LatestSalesPrice.value AS salesPrice, product.product_type AS productType FROM product full outer JOIN LatestSalesPrice ON product.product_id = LatestSalesPrice.fk_product_id where product_id = @productId;";
    private readonly string INSERT_SALES_PRICE = "insert into sales_price (creation_date, [value], fk_product_id) VALUES (@creationDate, @value, @fkProductId)";
    private readonly string FIND_PRODUCTS_BY_PART_OF_NAME = "SELECT product_id as ProductId, name, description, weight, size, color, current_stock, product_type FROM product WHERE name LIKE @partOfName;";
    private readonly string DELETE_SALES_PRICES_BY_ID = "DELETE FROM sales_price WHERE fk_product_id = @fkProductId";
    private readonly string DELETE_PRODUCT_BY_ID = "DELETE FROM product WHERE product_id = @productId";

    public ProductDAO(string connectionString) : base(connectionString)
    {
    }

    //This method is used for creating products to the webpage from our winforms application. 
    //The method takes a Product object in the params
    //The method returns the newly created productId.  
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

    //This method is used for deleting products on the webpage. 
    //The method takes a Product object in the params. 
    //´The method returns a boolean, true or false depending on the outcome. 
    public async Task<bool> DeleteAsync(Product entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            bool res = await connection.ExecuteAsync(DELETE_SALES_PRICES_BY_ID, new {fkProductId = entity.ProductId}, transaction) > 0;
            res = await connection.ExecuteAsync(DELETE_PRODUCT_BY_ID, new {productId = entity.ProductId}, transaction) > 0;
            if (!res)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
            return res;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Could not delete product with id: {entity.ProductId}. Message was: {ex.Message}", ex);
        }
    }

    //This method i used for getting all the products on the webpage. 
    //The method returns a IEnumerable<Product>
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var connection = CreateConnection();
        connection.Open();

        try
        {
            var products = await connection.QueryAsync<Product>(GET_PRODUCT_WITH_NEWEST_SALES_PRICE);
            connection.Close();
            return products;
        }
        catch (SqlException ex)
        {

            throw new Exception($"There was a problem getting all products. Error message was {ex.Message}");
        }
    }

    //This method is used for getting a product by its ID. 
    //The method takes a id in the params. 
    //And returns a product
    public async Task<Product> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();
        connection.Open();
        try
        {
            var product = await connection.QuerySingleAsync<Product>(SELECT_PRODUCT_BY_ID, new { productId = id });
            connection.Close();
            return product;
        }
        catch (SqlException ex)
        {

            throw new Exception($"Error getting product by id with id:{id}. The exception was:, {ex.Message}");
        }
    }

    public async Task<bool> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> FindProductsByPartOfNameAsync(string givenPartOfName)
    {
        using var connection = CreateConnection();

        string searchSQLString = "%" + givenPartOfName + "%";

        IEnumerable<Product> products = await connection.QueryAsync<Product>(FIND_PRODUCTS_BY_PART_OF_NAME, new { partOfName =  searchSQLString});
        return products;
    }
}
