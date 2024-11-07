using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;
//Der laves en statisk liste der holder på alle produkter. 
//Der laves 10 produkter, som tilføjes til listen. 
public class ProductDAOStub : IDAO<Product>
{
    private static List<Product> _products = new List<Product>() {
        new Product(1, "M", "Medium Sized Tent", "This tent is perfect for 2-3 persons, easy to set up, and very lightweight.", 4.2),
        new Product(2, "L", "Large Family Tent", "A spacious tent for 4-6 persons with extra storage space and weather-resistant materials.", 7.5),
        new Product(3, "S", "Small Backpacking Tent", "Compact and lightweight tent for solo travelers or couples.", 2.5),
        new Product(4, "M", "Camping Sleeping Bag", "Warm sleeping bag suitable for temperatures as low as 0°C.", 1.2),
        new Product(5, "L", "Double Sleeping Bag", "Comfortable sleeping bag for two, ideal for camping in cool temperatures.", 2.4),
        new Product(6, "M", "Camping Stove", "Portable and compact camping stove with adjustable flame.", 1.8),
        new Product(7, "One Size", "Camping Lantern", "Bright LED lantern with adjustable brightness and a long-lasting battery.", 0.9),
        new Product(8, "One Size", "Portable Water Filter", "Filter and purify water while camping or hiking, essential for outdoor survival.", 0.6),
        new Product(9, "M", "Hiking Backpack", "A 40L hiking backpack with multiple compartments and ergonomic design.", 1.3),
        new Product(10, "One Size", "Camping Chair", "Foldable, lightweight camping chair with cup holder, perfect for relaxing by the campfire.", 1.5)
    };
    //nextAvailableId, finder det sidste produkt i listen og plusser det fundte produkts id med 1. 
    //Id sættes på produkt 
    //Produktet tilføjes til listen.
    //Id'et returnes
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
    //Returnere hele listen af produkter
    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
    //I produkt listen, kigger vi efter medsendte id, der kigges igennem alle produkters id indtil der findes et der matcher det medsendte. 
    public Product GetById(int id)
    {
        return _products.First(product => product.ProductId == id);
    }

    public bool Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
