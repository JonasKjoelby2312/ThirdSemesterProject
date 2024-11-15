using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class Package : Component
{
    public string PackageId { get; set; }
    //Holds the componets within the package
    public List<Component> Components { get; set; } = new List<Component>();

    //constructer with base to initialize 
    //public Package(string name, string description, decimal weight) : base(name, description, weight)
    //{
    //}

    public void AddComponent(Component component) 
    {  
        Components.Add(component); 
    }

    public bool RemoveComponent(Component component) 
    { 
        return Components.Remove(component); 
    }

    public decimal GetTotalWeight()
    {
        decimal totalWeight = Weight;
        foreach (Component component in Components)
        {
            totalWeight += component.Weight;
        }
        return totalWeight;
    }

    public override string ToString()
    {
        return $"{Name}, Total weight: {GetTotalWeight()} kg, Description: {Description}";
    }
}