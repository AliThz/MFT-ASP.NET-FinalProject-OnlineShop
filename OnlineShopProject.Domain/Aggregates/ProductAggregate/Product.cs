using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.ProductAggregate
{
    public class Product : Frameworks.Base.Entity
    {
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get { return UnitPrice * Quantity; } }

        public List<OrderAggregate.OrderDetail> OrderDetails { get; set; }
    }
}
