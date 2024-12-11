using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.DAOs;
using NUnit.Framework;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.NUnitTest;

public class CustomerDAOTests
{
    
    private CustomerDAO _customerDAO;

    [SetUp]
    public void SetUp()
    {
        _customerDAO = new CustomerDAO("Server=tcp:hildur.ucn.dk,1433;Database=DMA-CSD-S232_10503126;User ID=DMA-CSD-S232_10503126;Password=Password1!;");
    }

    [Test]
    public async Task GetCustomerByIdTestSucces()
    {
        //Arrange 
        Customer customer = new Customer() { Name = "John Doe", Email = "john.doe@example.com" };
        //Act
        var customerToFind = await _customerDAO.GetByIdAsync(1);

        //Assert
        Assert.That(customerToFind, Is.Not.Null);
        Assert.That(customerToFind.Name, Is.EqualTo(customer.Name));
        Assert.That(customerToFind.Email, Is.EqualTo(customer.Email));
    }
    [Test]
    public async Task GetCustomerByIdTestFail()
    {
        //Arrange 
        Customer customer = new Customer() { Name = "Jane Doe", Email = "Jane.Doe@example.com" };
        //Act
        var customerToFind = await _customerDAO.GetByIdAsync(1);

        //Assert
        Assert.That(customerToFind, Is.Not.Null);
        Assert.That(customerToFind.Name, Is.EqualTo(customer.Name));
        Assert.That(customerToFind.Email, Is.EqualTo(customer.Email));

    }
    [Test]
    public async Task CreateCustomerTestSucces()
    {
        //Arrange 
        Customer customer = new Customer() { Name = "Jane Doe", Email = "Jane.Doe@example.com", 
            Address = new Address() {RoadName = "Road", City = "By", HouseNo = "1", Zip = 9000 }, 
            Password = "123", PersonType = "Person", PhoneNO = "56473829" };
        //Act
        var customerId =  await _customerDAO.CreateAsync(customer, customer.Password);
        

        //Assert
        Assert.That(customerId, Is.GreaterThan(0));

    }



}

