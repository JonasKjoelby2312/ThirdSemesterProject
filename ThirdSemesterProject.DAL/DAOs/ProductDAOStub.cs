using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;
//A static list is to hold the products. 
//10 products is, and added to the list. 
public class ProductDAOStub : IDAO<Product>
{
    private static List<Product> _products = new List<Product>() {
        new Product() { ProductId = 1, Name = "Large Family Tent", Description =  "A spacious tent for 4-6 persons with extra storage space and weather-resistant materials.", Weight = 7.5m, Size = "L", CurrentStock = 7, SalesPrice = 499.95m, Color = "Black", ProductType = "Equipment" },
        new Product() { ProductId = 2, Name = "Small Backpacking Tent", Description = "Compact and lightweight tent for solo travelers or couples.", Weight = 2.5m, Size = "S", CurrentStock = 10, SalesPrice = 199.95m, Color = "Green", ProductType = "Equipment" },
        new Product() { ProductId = 3, Name = "Camping Sleeping Bag", Description = "Warm sleeping bag suitable for temperatures as low as 0°C.", Weight = 1.2m, Size = "M", CurrentStock = 15, SalesPrice = 149.95m, Color = "Blue", ProductType = "Equipment" },
        new Product() { ProductId = 4, Name = "Double Sleeping Bag", Description = "Comfortable sleeping bag for two, ideal for camping in cool temperatures.", Weight = 2.4m, Size = "L", CurrentStock = 8, SalesPrice = 249.95m, Color = "Red", ProductType = "Equipment" },
        new Product() { ProductId = 5, Name = "Camping Stove", Description = "Portable and compact camping stove with adjustable flame.", Weight = 1.8m, Size = "M", CurrentStock = 20, SalesPrice = 99.95m, Color = "Silver", ProductType = "Equipment" },
        new Product() { ProductId = 6, Name = "Camping Lantern", Description = "Bright LED lantern with adjustable brightness and a long-lasting battery.", Weight = 0.9m, Size = "One Size", CurrentStock = 25, SalesPrice = 29.95m, Color = "Yellow", ProductType = "Clothes" },
        new Product() { ProductId = 7, Name = "Portable Water Filter", Description = "Filter and purify water while camping or hiking, essential for outdoor survival.", Weight = 0.6m, Size = "One Size", CurrentStock = 30, SalesPrice = 39.95m, Color = "White", ProductType = "Clothes" },
        new Product() { ProductId = 8, Name = "Hiking Backpack", Description = "A 40L hiking backpack with multiple compartments and ergonomic design.", Weight = 1.3m, Size = "M", CurrentStock = 18, SalesPrice = 149.95m, Color = "Black", ProductType = "Clothes" },
        new Product() { ProductId = 9, Name = "Camping Chair", Description = "Foldable, lightweight camping chair with cup holder, perfect for relaxing by the campfire.", Weight = 1.5m, Size = "One Size", CurrentStock = 50, SalesPrice = 39.95m, Color = "Brown", ProductType = "Clothes" },
        new Product() { ProductId = 10, Name = "Insulated Cooler Box", Description = "Durable cooler box with excellent insulation to keep food and drinks cold for hours.", Weight = 4.0m, Size = "L", CurrentStock = 12, SalesPrice = 79.95m, Color = "White", ProductType = "Equipment" }

    };
    //The variable nextAvailableId, gets the id of the last item in the list, and adds one,
    //so we have the correct value
    //The new product gets the nextAvailableId as ProductID
    //The newly created product get added to the list
    //The method return the nextAvailableId
    public int Create(Product entity)
    {
        var nextAvailableId = _products.Max(entity => entity.ProductId) + 1;
        entity.ProductId = nextAvailableId;
        _products.Add(entity);
        return entity.ProductId;
         
    }

    public bool Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    //Returns the all products
    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public IEnumerable<Product> GetAllEquipment()
    {
        return _products.Where(product => product.ProductType == "Equipment");
    }

    public IEnumerable<Product> GetAllClothes()
    {
        return _products.Where(product => product.ProductType == "Clothes");
    }

    //The method gets an id in the paramaters, and uses that to look through the list of products,
    //To find the one that matches the one sent in the parameters
    public Product GetById(int id)
    {
        Product productToReturn = _products.FirstOrDefault(product => product.ProductId == id);
        return productToReturn;
    }

    public bool Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
