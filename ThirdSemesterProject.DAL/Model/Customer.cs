using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.DAL.Model;

public class Customer : Person
{
    public Customer(int personId, string name, string email, string phoneNO, string passwordHash) : base(personId, name, email, phoneNO, passwordHash)
    {
    }
}
