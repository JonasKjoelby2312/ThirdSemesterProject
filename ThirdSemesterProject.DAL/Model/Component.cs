using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public abstract class Component
{
    public int ComponentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }

    protected Component()
    {
        
    }

}
