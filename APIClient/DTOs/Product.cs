using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.DTOs
{
    public class Product
    {
        #region Properties 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public decimal SalesPrice { get; set; }
        public int CurrentStock { get; set; }
        #endregion
    }
}
