using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class Package : Component
{
    
    //Holds the componets within the package
    public List<Component> Components { get; set; } = new List<Component>();

    //constructer with base to initialize 
    public Package(string name, string description, double weight) : base(name, description, weight)
    {
    }

    public void AddComponent(Component component) 
    {  
        Components.Add(component); 
    }

    public bool RemoveComponent(Component component) 
    { 
        return Components.Remove(component); 
    }

    public double GetTotalWeight()
    {
        double totalWeight = Weight;
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