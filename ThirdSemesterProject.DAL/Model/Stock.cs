using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class Stock
{
    public required int MinStock {  get; set; }
    public required int MaxStock { get; set; }
    public required int CurrentStock { get; set; }
    public required string Placement { get; set; }

    public Stock(int minStock, int maxStock, int currentStock, string placement)
    {
        MinStock = minStock;
        MaxStock = maxStock;
        CurrentStock = currentStock;
        Placement = placement;
    }

    public void AddStock(int amount)
    {
        if (CurrentStock + amount > MaxStock)
        {
            throw new InvalidOperationException("Cannot exceed maximum stock limit.");
        }
        CurrentStock += amount;
    }

    public void RemoveStock(int amount)
    {
        if (CurrentStock  - amount < MinStock)
        {
            throw new InvalidOperationException("Cannot go below minimum stock limit.");
        }
        CurrentStock -= amount;
    }

    public bool RestockNeeded()
    {
        return CurrentStock <= MinStock;
    }

    public override string ToString()
    {
        return $"Stock location: {Placement}, Current stock: {CurrentStock}, Minimum stock: {MinStock}, Maximum stock: {MaxStock}";
    }
}
