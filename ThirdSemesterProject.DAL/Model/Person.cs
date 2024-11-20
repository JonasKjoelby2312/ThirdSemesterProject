using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public abstract class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNO { get; set; }
    public string PasswordHash { get; set; }

    public string PersonType { get; set; }

    public Person()
    {
    }
}
