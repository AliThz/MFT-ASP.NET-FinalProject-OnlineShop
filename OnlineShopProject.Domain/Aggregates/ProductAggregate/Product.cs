using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.ProductAggregate
{
    public class Product : Frameworks.Base.Entity
    {
        #region [ - Ctor - ]
        public Product(string title, decimal unitPrice, decimal quantity)
        {
            Title = title;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        #endregion

        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        public List<OrderAggregate.OrderDetail> OrderDetails { get; set; }
    }
}
