using APIClient.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIClient;

public class GUIAPIClient : IAPIClient
{
    private RestClient _restClient;
    public GUIAPIClient(string baseUrl) => _restClient = new RestClient(baseUrl);


    public async Task<int> CreateProductAsync(Product entity)
    {
        var response = await _restClient.RequestAsync<int>(Method.Post, "products", entity);
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error Creating Product. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var response = await _restClient.RequestAsync<int>(Method.Delete, $"products/{id}", null);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else
        {
            throw new Exception($"Error Deleting Product with id = {id}. Message was {response.Content}");
        }
    }

    //Skal ikke bruges pt. vi vil gerne kunne få 10 producter via Id
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<Product>>(Method.Get, $"Products");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error Retriving Product. Message was {response.Content}");
        }
        return response.Data;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<Product>(Method.Get, $"products/{id}");
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error Getting Product by id = {id}. Message was {response.Content}");

        }
        return response.Data;
    }

    public async Task<bool> UpdateProductAsync(Product entity)
    {
        var response = await _restClient.RequestAsync(Method.Put, $"products/{entity.ProductId}", entity);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else
        {
            throw new Exception($"Error Updating Product with id = {entity}. Message was {response.Content}");
        }
    }
}
