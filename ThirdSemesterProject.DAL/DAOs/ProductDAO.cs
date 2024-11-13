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
    private readonly string GET_ALL_PRODUCTS = "SELECT component_id, name, description, weight, size, color, current_stock from component RIGHT OUTER JOIN product on fk_component_id = component_id;";
    private readonly string INSERT_PRODUCT = "INSERT INTO product values size = @size, color = @color, current_stock = @current_stock;";
    private readonly string INSERT_COMPONENT = "INSERT INTO component name = @name, description = @description, weight = @weight;";


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
        var products = await connection.QueryAsync<Product>(GET_ALL_PRODUCTS);
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
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
