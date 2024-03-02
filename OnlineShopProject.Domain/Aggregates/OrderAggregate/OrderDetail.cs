using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.OrderAggregate
{
    public class OrderDetail
    {
        #region [ - Ctor - ]
        public OrderDetail(Guid orderHeaderId, Guid productId, decimal quantity)
        {
            OrderHeaderId = orderHeaderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public OrderDetail()
        {
                
        }
        #endregion

        public Guid OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public Guid ProductId { get; set; }
        public ProductAggregate.Product Product { get; set; }

        public decimal Quantity { get; set; }
        //public decimal Price { get { return Product.UnitPrice * Quantity; } }
    }
}
