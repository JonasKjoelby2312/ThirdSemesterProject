using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.APIClient;

public class APIClient : IAPIClient
{
    private RestClient _restClient;
    public APIClient(string baseUrl) => _restClient = new RestClient(baseUrl);

    public async Task<int> CreateCustomerAsync(CustomerDTO customerDTO)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "Customers", customerDTO);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error creating user with email: {customerDTO.Email}. Message was: {response.Content}");
        }
        return response.Data;
    }

    public async Task<int> CreateProductAsync(ProductDTO entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "products", entity);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Creating Product. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<int> CreateSaleOrderAsync(SaleOrderDTO entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "saleOrders", entity);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Creating Product. Message was {response.Content}");
        }
        return response.Data;
    }

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

    //Skal ikke bruges pt. vi vil gerne kunne få 10 producter via Id
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<ProductDTO>>(Method.Get, $"Products");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Retriving Product. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<CustomerDTO> GetCustomerByIdAsync(int userId)
    {
        var response = await _restClient.RequestAsync<CustomerDTO>(Method.Get, $"Customers/{userId}");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error retrieving customer with Id: {userId}. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<ProductDTO>(Method.Get, $"products/{id}");
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error Getting Product by id = {id}. Message was {response.Content}");

        }
        return response.Data;
    }

    public async Task<int> LoginAsync(CustomerDTO loginInfo)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, $"logins", loginInfo);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error loggin in for customer with Email = {loginInfo.Email}. Message was {response.Content}");

        }
        return response.Data;
    }

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
