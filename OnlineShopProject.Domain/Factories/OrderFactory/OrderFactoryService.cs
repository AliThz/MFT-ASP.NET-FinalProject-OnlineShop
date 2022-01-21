using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Factories.OrderFactory
{
    [ScopedService]
    public class OrderFactoryService
    {
        #region [ - Ctor - ]
        public OrderFactoryService(Reporities.IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }
        #endregion

        #region [ - Prop - ]
        public Reporities.IOrderRepository OrderRepository { get; set; }
        #endregion

        #region [ - Method - ]

        #region [ - CreateAsync(Aggregates.PersonAggregate.Person seller, Aggregates.PersonAggregate.Person buyer, List<Aggregates.OrderAggregate.OrderDetail> orderDetails) - ]
        public Task<Aggregates.OrderAggregate.OrderHeader> CreateAsync(Aggregates.PersonAggregate.Person seller, Aggregates.PersonAggregate.Person buyer, List<Aggregates.OrderAggregate.OrderDetail> orderDetails)
        {
            return Task.FromResult(new Aggregates.OrderAggregate.OrderHeader(seller, buyer, orderDetails));
        }
        #endregion

        #endregion
    }
}
