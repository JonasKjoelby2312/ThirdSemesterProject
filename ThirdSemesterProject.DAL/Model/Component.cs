using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public abstract class Component
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }

    //protected Component(string name, string description, decimal weight)
    //{
    //    Name = name;
    //    Description = description;
    //    Weight = weight;
    //}

}
