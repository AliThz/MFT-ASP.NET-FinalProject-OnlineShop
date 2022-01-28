using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.OrderAggregate
{
    public class OrderHeader : Frameworks.Base.Entity
    {
        #region [ - Ctor - ]
        public OrderHeader(Aggregates.PersonAggregate.Person seller, Aggregates.PersonAggregate.Person buyer, List<Aggregates.OrderAggregate.OrderDetail> orderDetails)
        {
            Seller = seller;
            Buyer = buyer;
            OrderDetails = orderDetails;
        }

        public OrderHeader()
        {

        }
        #endregion

        public PersonAggregate.Person Seller { get; set; }
        public PersonAggregate.Person Buyer { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
