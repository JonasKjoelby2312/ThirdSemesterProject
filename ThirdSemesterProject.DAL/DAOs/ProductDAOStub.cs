﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs;
//A static list gets created to hold our products. 
//10 products gets created, and added to the list. 
public class ProductDAOStub : IDAO<Product>
{
    private static List<Product> _products = new List<Product>() {
        new Product(1, "M", 12, 399.95m, "Medium Sized Tent", "This tent is perfect for 2-3 persons, easy to set up, and very lightweight.", 4.2),
        new Product(2, "L", 7, 499.95m, "Large Family Tent", "A spacious tent for 4-6 persons with extra storage space and weather-resistant materials.", 7.5),
        new Product(3, "S", 10, 199.95m, "Small Backpacking Tent", "Compact and lightweight tent for solo travelers or couples.", 2.5),
        new Product(4, "M", 15, 149.95m, "Camping Sleeping Bag", "Warm sleeping bag suitable for temperatures as low as 0°C.", 1.2),
        new Product(5, "L", 8, 249.95m, "Double Sleeping Bag", "Comfortable sleeping bag for two, ideal for camping in cool temperatures.", 2.4),
        new Product(6, "M", 20, 99.95m, "Camping Stove", "Portable and compact camping stove with adjustable flame.", 1.8),
        new Product(7, "One Size", 25, 29.95m, "Camping Lantern", "Bright LED lantern with adjustable brightness and a long-lasting battery.", 0.9),
        new Product(8, "One Size", 30, 39.95m, "Portable Water Filter", "Filter and purify water while camping or hiking, essential for outdoor survival.", 0.6),
        new Product(9, "M", 18, 149.95m, "Hiking Backpack", "A 40L hiking backpack with multiple compartments and ergonomic design.", 1.3),
        new Product(10, "One Size", 50, 39.95m, "Camping Chair", "Foldable, lightweight camping chair with cup holder, perfect for relaxing by the campfire.", 1.5)

    };
    //The variable nextAvailableId, gets the id of the last item in the list, and adds one,
    //so we have the correct value
    //The new product gets the nextAvailableId as ProductID
    //The newly created product get added to the list
    //The method return the nextAvailableId
    public int CreateAsync(Product entity)
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
    //Returns the whole list of products
    public IEnumerable<Product> GetAllAsync()
    {
        return _products;
    }
//The method gets an id in the paramaters, and uses that to look through the list of products,
//to find the one that matches the one sent in the parameters
    public Product GetByIdAsync(int id)
    {
        return _products.First(product => product.ProductId == id);
    }

    public bool Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
