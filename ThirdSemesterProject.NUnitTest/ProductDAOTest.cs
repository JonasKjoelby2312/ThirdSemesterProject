using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.NUnitTest
{
    public class ProductDAOTest
    {
        private List<int> _idsToCleanUp = new List<int>();
        private ProductDAO _productDAO;

        [OneTimeSetUp]
        public void SetupDAO()
        {
            _productDAO = new ProductDAO("Server=tcp:hildur.ucn.dk,1433;Database=DMA-CSD-S232_10503126;User ID=DMA-CSD-S232_10503126;Password=Password1!;");
        }

        [OneTimeTearDown]
        public async Task DeleteAllTestDataAsync()
        {
            IEnumerable<Product> testProducts = await _productDAO.FindProductsByPartOfNameAsync("TESTDATA");
            
            foreach (Product testProduct in testProducts)
            {
                await _productDAO.DeleteAsync(testProduct);
            }
        }

        [Test]
        public async Task CreateAsyncTestSuccessAsync()
        {
            Product p = new Product() { Name = "[TESTDATA] External Urine Tank", Color = "Brown", CurrentStock = 59, Description = "An external tank, for all your urine needs.", ProductType = "Equipment", SalesPrice = 200, Size = "Small", Weight = 15};
            
            int pId = await _productDAO.CreateAsync(p);

            Product pInDB = await _productDAO.GetByIdAsync(pId);

            Assert.That(pInDB.Name.Equals(p.Name));
            Assert.That(pInDB.SalesPrice.Equals(p.SalesPrice));
        }

        [Test]
        public async Task DeleteAsyncSuccessAsync()
        {
            Product p = new Product() { Name = "[TESTDATA] Bear-Away", Color = "Blue", CurrentStock = 7, Description = "A can of anti-bear spray, very handy and only smells a little of diarrhea.", ProductType = "Equipment", SalesPrice = 75, Size = "Small", Weight = 0.5m };

            int pId = await _productDAO.CreateAsync(p);
            p.ProductId = pId;

            bool res = await _productDAO.DeleteAsync(p);

            Assert.That(res, Is.True);
        }

        [Test]
        public async Task FindProductsByPartOfNameAsyncSuccessAsync()
        {
            IEnumerable<Product> products = await _productDAO.FindProductsByPartOfNameAsync("TESTDATA");
            int amount = products.Count();
            Assert.That(amount > 0);
        }
    }
}
