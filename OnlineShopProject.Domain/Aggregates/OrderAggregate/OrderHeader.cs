using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.OrderAggregate
{
    public class OrderHeader : Frameworks.Base.Entity
    {
        public PersonAggregate.Person Seller { get; set; }
        public PersonAggregate.Person Buyer { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
