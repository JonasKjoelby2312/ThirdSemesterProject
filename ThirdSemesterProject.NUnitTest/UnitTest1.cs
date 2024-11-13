using NUnit.Framework;
using System;
using System.Collections.Generic;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.Model;

public class SaleOrderTests
{
    //DENNE KLASSE VIRKER IKKE SÅ VÆR IK BANGE FOR AT PILLE I DEN
    private Customer _customer;
    private SaleOrderDTO _saleOrder;
    private IAPIClient _client;
    private SaleOrder _sale;
    private List<OrderLineDTO> orderlines;

    [SetUp]
    public async Task SetupAsync()
    {
        _client = new APIClient("https://localhost:7027/api/");

        _customer = new Customer(1, "Senad", "Senad@mathle.com", "12345678", "Jonaspassword");

        //var orderline = new List<OrderLineDTO>
        //{
        //    new OrderLineDTO {Quantity = 1, UnitPrice = 12m},
        //    new OrderLineDTO {Quantity = 2, UnitPrice = 11m}
        //};

        

        _saleOrder = new SaleOrderDTO
        {
            OrderDate = DateTime.Now,
            Total = 0,
            Customer = new CustomerDTO
            {
                PersonId = _customer.PersonId,
                Name = _customer.Name,
                Email = _customer.Email,
                PhoneNO = _customer.PhoneNO,
                PasswordHash = _customer.PasswordHash  
            },
            OrderLines = new List<OrderLineDTO>
            {
                new OrderLineDTO {Quantity = 1, UnitPrice = 12m},
                new OrderLineDTO {Quantity = 2, UnitPrice = 11m}
            }
        };

    }

    
    [Test]
    public async Task TestSaleOrder()
    {
        int SaleOrderId = await _client.CreateSaleOrderAsync(_saleOrder);


        Assert.That(SaleOrderId, Is.GreaterThan(0), "ffs");
    }


}
