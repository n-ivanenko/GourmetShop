using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GourmetShop.DataAccess.Entities;

namespace GourmetShop.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
