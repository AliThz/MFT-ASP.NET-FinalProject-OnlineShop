using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.OrderAggregate
{
    public class OrderHeader : Frameworks.Base.Entity
    {
        #region [ - Ctor - ]
        public OrderHeader(Aggregates.PersonAggregate.Person seller, Aggregates.PersonAggregate.Person buyer)
        {
            Seller = seller;
            Buyer = buyer;
        }

        public OrderHeader()
        {

        }
        #endregion

        public PersonAggregate.Person Seller { get; set; }
        [JsonIgnore]
        public Guid SellerId { get; set; }

        public PersonAggregate.Person Buyer { get; set; }
        [JsonIgnore]
        public Guid buyerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
