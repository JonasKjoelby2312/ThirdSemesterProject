    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ThirdSemesterProject.DAL.Model;

    public class SalesPrice
    {
        public required DateTime CreationDate { get; set; }
        public required decimal Value { get; set; }

        public SalesPrice(DateTime creationDate, decimal value)
        {
            CreationDate = creationDate;
            Value = value;
        }
    
}
