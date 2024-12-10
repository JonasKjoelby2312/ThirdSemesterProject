﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient;

/// <summary>
/// Provides extension methods for the <see cref="RestClient"/>
/// </summary>
public static class RestClientExtensions
{

    /// <summary>
    /// lidt i usikker på
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="client"></param>
    /// <param name="method"></param>
    /// <param name="resource"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static async Task<RestResponse<T>> RequestAsync<T>(this RestClient client, Method method, string resource = null, object body = null)
    {
        var request = new RestRequest(resource, method);
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync<T>(request, method);
    }

    /// <summary>
    /// og den her
    /// </summary>
    /// <param name="client"></param>
    /// <param name="method"></param>
    /// <param name="resource"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static async Task<RestResponse> RequestAsync(this RestClient client, Method method, string resource = null, object body = null)
    {
        var request = new RestRequest(resource, method);
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync(request, method);
    }

}
