using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.WebSite.Controllers;

namespace ThirdSemesterProject.NUnitTest;

public class APIClientTests
{
    private IAPIClient _client;

    [OneTimeSetUp]
    public void Setup()
    {
        _client = new APIClient.APIClient("https://localhost:7027/api/");
    }

    [Test]
    public async Task GetAllProductsAsyncSuccess()
    {
        IEnumerable<ProductDTO> products = await _client.GetAllProductsAsync();

        Assert.IsNotNull(products);
        //Assert.That(products.Count().Equals(20));
    }

    [Test]
    public async Task GetProductByIdAsyncSuccess()
    {
        ProductDTO product = await _client.GetProductByIdAsync(5);

        Assert.IsNotNull(product);
        Assert.That(product.Name.Equals("Double Sleeping Bag"));
        Assert.That(product.SalesPrice.Equals(250));
    }

    [Test]
    public async Task GetCustomerByIdAsyncSuccess()
    {
        CustomerDTO c = await _client.GetCustomerByIdAsync(5);

        Assert.IsNotNull(c);
        Assert.That(c.Name.Equals("Charlie Green"));
    }

    [Test]
    public async Task CreateProductAsyncSuccess()
    {
        //Assign
        ProductDTO p = new ProductDTO() { Name = "Bear Grill", Color = "Steel", CurrentStock = 54, Description = "A bear-sized grill tray, produced in the shein factory", ProductType = "Equipment", SalesPrice = 150, Size = "XL", Weight = 0.5m};

        //Act
        p.ProductId = await _client.CreateProductAsync(p);
        ProductDTO fetchedProduct = await _client.GetProductByIdAsync(p.ProductId);

        //Assert
        Assert.That(p.ProductId > 0);
        Assert.IsNotNull(fetchedProduct);
        Assert.That(p.Name.Equals(fetchedProduct.Name));
    }
}
