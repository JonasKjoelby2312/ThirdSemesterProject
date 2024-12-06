using AspNetCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.Controllers;

namespace ThirdSemesterProject.NUnitTest;

public class APIProductsControllerTest
{
    private ProductsController _productsController;
    private Mock<IProductDAO> _mockProductsDAO;

    public APIProductsControllerTest()
    {
        _mockProductsDAO = new Mock<IProductDAO>();
        _productsController = new ProductsController( _mockProductsDAO.Object );
    }

    [Test]
    public async Task GetAllProductsReturnsOkCode()
    {
        //Arange

        var expectedProducts = new List<Product>()
        {
            new Product() {ProductId = 1, SalesPrice = 400},
            new Product() {ProductId = 2, SalesPrice = 500},
            new Product() {ProductId = 3, SalesPrice = 200},
            new Product() {ProductId = 4, SalesPrice = 150},
            new Product() {ProductId = 5, SalesPrice = 250},
            new Product() {ProductId = 6, SalesPrice = 100},
            new Product() {ProductId = 7, SalesPrice = 30 },
            new Product() {ProductId = 8, SalesPrice = 40},
            new Product() {ProductId = 9, SalesPrice = 150},
            new Product() {ProductId = 10, SalesPrice = 40}
        };

        _mockProductsDAO.Setup(dao => dao.GetAllAsync()).ReturnsAsync(expectedProducts);

        //Act 
        var result = _productsController.GetAllAsync();

        //Assert
    }
}
