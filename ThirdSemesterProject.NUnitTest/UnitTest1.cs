using NUnit.Framework.Constraints;
using ThirdSemesterProject.APIClient;

namespace ThirdSemesterProject.NUnitTest;

public class Tests
{
    private IAPIClient _client;
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestCreateSaleOrder()
    {
        var product = _client.GetProductByIdAsync(1);
        var product1 = _client.GetProductByIdAsync(2);
        Assert.Pass();
    }
}