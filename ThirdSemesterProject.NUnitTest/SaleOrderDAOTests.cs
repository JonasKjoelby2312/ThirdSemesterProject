using NUnit.Framework;
using System;
using System.Collections.Generic;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

//Testing of the SaleOrderDAO class.
public class SaleOrderDAOTests
{
    private SaleOrderDAO saleOrderDAO;
    private SaleOrder _sale;

    [SetUp]
    public void Setup()
    {
        saleOrderDAO = new SaleOrderDAO();

    }

    [Test]
    public async Task TestSaleOrder()
    {

    }


}
