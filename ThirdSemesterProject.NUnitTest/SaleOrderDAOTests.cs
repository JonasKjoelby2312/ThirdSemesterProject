/*using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
        saleOrderDAO = new SaleOrderDAO("Data Source=.;Initial Catalog=webshop;Integrated Security=True");

        Customer c = new Customer(99, "Epstein", "epstein@island.org", "12345678", "unr34d4bl3");
        _sale = new SaleOrder(c);
        Product p1 = new Product(97, "Double Wide", 2, 199.95m, "Equipment", "'Diddy'nt Do It' T-Shirt", "A singular t-shirt with the text: 'Diddynt Do It' printed on top. Low quality.'", 0.05);
        _sale.AddOrderLineToSaleOrder(new OrderLine(p1, 12));
    }

    [Test]
    public async Task TestSaleOrderCreateAsync()
    {
        Assert.DoesNotThrowAsync(async () => await saleOrderDAO.CreateAsync(_sale));
    }


}
*/

using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

//Testing of the SaleOrderDAO class.
public class SaleOrderDAOTests
{
    private SaleOrderDAO _saleOrderDAO;
    private SaleOrder _saleOrder;


    [SetUp]
    public void Setup()
    {
        _saleOrderDAO = new SaleOrderDAO("Server=tcp:hildur.ucn.dk,1433;Database=DMA-CSD-S232_10503126;User ID=DMA-CSD-S232_10503126;Password=Password1!;");

        Customer customer = new Customer() {Name = "Dude", Email = "Dude@gmail.com", Address = new Address() {RoadName = "dudestreet", City = "DudeCity", HouseNo = "69", Zip = 9999 } };
        SaleOrder _saleOrder = new SaleOrder(customer);
        Product product1 = new Product() { Name = "fack", Color = "redfack", CurrentStock = 2, Description = "fack is fack", ProductType = "Equipment", SalesPrice = new SalesPrice() { CreationDate = DateTime, Value = 2 }, Size = "L",  };
        _saleOrder.AddOrderLineToSaleOrder(new OrderLine(product1, 12));
    }

    [Test]
    public async Task TestSaleOrderCreateAsync()
    {
        //Arrange
        

        //Act

        //Assert

        Assert.DoesNotThrowAsync(async () => await saleOrderDAO.CreateAsync(_saleOrder));
    }


}