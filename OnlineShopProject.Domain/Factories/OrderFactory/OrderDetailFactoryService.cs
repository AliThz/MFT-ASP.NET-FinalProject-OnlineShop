using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Factories.OrderFactory
{
    [ScopedService]
    public class OrderDetailFactoryService
    {
        #region [ - Ctor - ]
        public OrderDetailFactoryService(Reporities.IOrderDetailRepository orderDetailRepository)
        {
            OrderDetailRepository = orderDetailRepository;
        }
        #endregion

        #region [ - Prop - ]
        public Reporities.IOrderDetailRepository OrderDetailRepository { get; set; }
        #endregion

        #region [ - Method - ]

        #region [ - CreateAsync(Guid orderHeaderId, Guid productId, decimal quantity) - ]
        public async Task<Aggregates.OrderAggregate.OrderDetail> CreateAsync(Guid orderHeaderId, Guid productId, decimal quantity)
        {
            //var orderDetail = OrderDetailRepository.FindOrderDetailAsync(orderHeaderId, productId);
            //if (orderDetail == null)
            //{
            //    return new Aggregates.OrderAggregate.OrderDetail(orderHeaderId, productId, quantity);
            //}
            //return null;
            //else
            //{
            //    orderDetail.Result.Quantity += quantity;
            //    await OrderDetailRepository.UpdateAsync(orderDetail.Result);
            //    return await orderDetail;
            //}
            return new Aggregates.OrderAggregate.OrderDetail(orderHeaderId, productId, quantity);
        }
        #endregion

        #region [ - CreateListAsync(Guid orderHeaderId, Guid productId, decimal quantity) - ]
        public async Task<List<Aggregates.OrderAggregate.OrderDetail>> CreateListAsync()
        {
            return new List<Aggregates.OrderAggregate.OrderDetail>();
        }
        #endregion

    #endregion
    }
}
