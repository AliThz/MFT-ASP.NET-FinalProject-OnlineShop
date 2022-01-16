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
        //#region [ - Ctor - ]
        //public OrderDetailFactoryService(Reporities.IOrderDetailRepository orderDetailRepository)
        //{
        //    OrderDetailRepository = orderDetailRepository;
        //}
        //#endregion

        //#region [ - Prop - ]
        //public Reporities.IOrderDetailRepository OrderDetailRepository { get; set; }
        //#endregion

        //#region [ - Method - ]

        //#region [ - CreateAsync(Aggregates.OrderAggregate.OrderHeader orderHeader, Aggregates.ProductAggregate.Product product, decimal quantity) - ]
        //public async Task<Aggregates.OrderAggregate.OrderDetail> CreateAsync(Aggregates.OrderAggregate.OrderHeader orderHeader, Aggregates.ProductAggregate.Product product, decimal quantity)
        //{
        //    //var requestedOrderDetail = OrderDetailRepository.FindOrderDetailAsync(orderHeader, product, quantity);
        //    //if (requestedOrderDetail == null)
        //    //{
        //    //    return new Aggregates.OrderAggregate.OrderDetail(/*orderHeader, product, quantity*/);
        //    //}
        //    //else
        //    //{
        //    //    requestedOrderDetail.Result.Quantity += quantity;
        //    //    await OrderDetailRepository.UpdateAsync(requestedOrderDetail.Result);
        //    //    return null;
        //    //}
        //    return new Aggregates.OrderAggregate.OrderDetail(/*orderHeader, product, quantity*/);
        //}
        //#endregion

        //#endregion
    }
}
