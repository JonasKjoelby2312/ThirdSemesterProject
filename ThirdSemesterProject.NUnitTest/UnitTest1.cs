using NUnit.Framework;
using System;
using System.Collections.Generic;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.Model;

public class SaleOrderTests
{
    private Customer customer;
    private SaleOrderDTO _saleOrder;
    private IAPIClient _client;
    private SaleOrder _sale;

    [SetUp]
    public async Task SetupAsync()
    {
        

    }

    [Test]
    public async Task TestSaleOrder()
    {
        int number = await _client.CreateSaleOrderAsync(_saleOrder);

    }


}
