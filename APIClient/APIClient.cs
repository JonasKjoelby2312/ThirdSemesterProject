using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.APIClient;

/// <summary>
/// A client to interact with the RESTful API for the operations regarding: Product, Customer, SaleOrders and Login for the Customer.
/// This class implements the interface: IAPIClient.
/// </summary>
public class APIClient : IAPIClient
{
    private RestClient _restClient;

    /// <summary>
    /// Creates a new instance of the <see cref="APIClient"/> With the baseUrl.
    /// </summary>
    /// <param name="baseUrl"></param>
    public APIClient(string baseUrl) => _restClient = new RestClient(baseUrl);

    /// <summary>
    /// Creates a new Customer in the system.
    /// </summary>
    /// <param name="customerDTO">Uses the details for the customer to be created.</param>
    /// <returns>The ID for the new customer.</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if there is an error creating customer.</exception>
    public async Task<int> CreateCustomerAsync(CustomerDTO customerDTO) //evt. ændre customerDTO til entity som i de andre methods
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "Customers", customerDTO);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error creating user with email: {customerDTO.Email}. Message was: {response.Content}");
        }
        return response.Data;
    }

    /// <summary>
    /// Creates a new product in the system.
    /// </summary>
    /// <param name="entity">Uses the details for the product to be created.</param>
    /// <returns>The product ID for the new product created.</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if there is an error creating a product.</exception>
    public async Task<int> CreateProductAsync(ProductDTO entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "products", entity);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Creating Product. Message was {response.Content}");
        }
        return response.Data;
    }

    /// <summary>
    /// Creates a saleOrder in the system.
    /// </summary>
    /// <param name="entity">Uses the details for a sale order to be created.</param>
    /// <returns>A sale order ID for the created sale order.</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if there is an error creating a sale order.</exception>
    public async Task<int> CreateSaleOrderAsync(SaleOrderDTO entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "saleOrders", entity);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Creating Product. Message was {response.Content}"); //error creating saleOrder??
        }
        return response.Data;
    }

    /// <summary>
    /// Deletes a product from the system using id.
    /// </summary>
    /// <param name="id">the id used to delete.</param>
    /// <returns>true if it was deleted.</returns>
    /// <exception cref="HttpRequestException">thros an HttpRequestException if it fails to delete.</exception>
    public async Task<bool> DeleteProductAsync(int id)
    {
        var response = await _restClient.RequestAsync<int>(Method.Delete, $"products/{id}");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else
        {
            throw new HttpRequestException($"Error Deleting Product with id = {id}. Message was {response.Content}");
        }
    }

    /// <summary>
    /// Retrives all products from the database.
    /// </summary>
    /// <returns>a collection of all products</returns>
    /// <exception cref="HttpRequestException">If it fails it throws an HttpRequestException with the response.</exception>
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<ProductDTO>>(Method.Get, $"Products");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Retriving Products. Message was {response.Content}");
        }
        return response.Data;
    }

    /// <summary>
    /// Retrives a customer
    /// </summary>
    /// <param name="userId">Uses userId to retrive the customer.</param>
    /// <returns>true if a customer is retrived.</returns>
    /// <exception cref="HttpRequestException">Throws an HttpRequestException if there is an error retriving a customer with id.</exception>
    public async Task<CustomerDTO> GetCustomerByIdAsync(int userId)
    {
        var response = await _restClient.RequestAsync<CustomerDTO>(Method.Get, $"Customers/{userId}");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error retrieving customer with Id: {userId}. Message was {response.Content}");
        }
        return response.Data;
    }

    /// <summary>
    /// Retrives a single product.
    /// </summary>
    /// <param name="id">Uses the id to return the product.</param>
    /// <returns>True if it retrives the product.</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if there is error getting the product.</exception>
    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<ProductDTO>(Method.Get, $"products/{id}");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Getting Product by id = {id}. Message was {response.Content}");

        }
        return response.Data;
    }

    /// <summary>
    /// LoginAsync is used to authenticate a customer.
    /// </summary>
    /// <param name="loginInfo">Login info from the customer.</param>
    /// <returns>true if the customer is logged in.</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if it fails because of wrong login info.</exception>
    public async Task<int> LoginAsync(CustomerDTO loginInfo)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, $"logins", loginInfo);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error loggin in for customer with Email = {loginInfo.Email}. Message was {response.Content}");

        }
        return response.Data;
    }

    /// <summary>
    /// Uses product id to update a product.
    /// </summary>
    /// <param name="entity">the id of the product.</param>
    /// <returns>true if the product is updated.</returns>
    /// <exception cref="HttpRequestException">throws and HttpRequestException if the product is not updated.</exception>
    public async Task<bool> UpdateProductAsync(ProductDTO entity)
    {
        var response = await _restClient.RequestAsync(Method.Put, $"products/{entity.ProductId}", entity);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else
        {
            throw new HttpRequestException($"Error Updating Product with id = {entity}. Message was {response.Content}");
        }
    }

    /// <summary>
    /// This method returns all the sale orders which is associated to a specific customer.
    /// </summary>
    /// <param name="id">Uses customer id.</param>
    /// <returns>a collection of saleOrders associated with customer</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if there is an error returning sale orders using the customer id.</exception>
    public async Task<IEnumerable<SaleOrderDTO>> GetAllSaleOrdersByPersonIdAsync(int id)
    {
        var request = new RestRequest($"SaleOrders", Method.Get);
        request.AddParameter("id", id);
        var response = await _restClient.ExecuteAsync<IEnumerable<SaleOrderDTO>>(request);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error getting all sales for customer with id:{id}");
        }
        return response.Data;
    }

    /// <summary>
    /// The method uses the saleOrderID to get OrderLineWithProducts.
    /// </summary>
    /// <param name="id">Uses the sale order id to retrive the orderline.</param>
    /// <returns>a collection of orderlines</returns>
    /// <exception cref="HttpRequestException">throws an HttpRequestException if there is an error returning the orderlines.</exception>
    public async Task<IEnumerable<OrderLineWithProductsDTO>> GetAllOrderLinesWithProductsBySaleOrderIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<IEnumerable<OrderLineWithProductsDTO>> (Method.Get, $"SaleOrders/{id}");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error getting order line with products id was:{id}. Message was {response.Content}");

        }
        return response.Data;
    }
}
