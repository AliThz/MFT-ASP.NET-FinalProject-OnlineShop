using AutoMapper;
using OnlineShopProject.Application.DTOs.OrderDetailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Services
{
    public class OrderDetailApplicationService : Abstracts.IOrderDetailApplicationService
    {
        #region [ - Ctor - ]
        public OrderDetailApplicationService(Domain.Reporities.IOrderDetailRepository orderDetailRepository,
                                             Domain.Factories.OrderFactory.OrderDetailFactoryService orderDetailFactory,
                                             IMapper mapper)
        {
            OrderDetailRepository = orderDetailRepository;
            OrderDetailFactory = orderDetailFactory;
            Mapper = mapper;
        }
        #endregion

        #region [ - Props - ]
        public Domain.Reporities.IOrderDetailRepository OrderDetailRepository { get; set; }
        public Domain.Factories.OrderFactory.OrderDetailFactoryService OrderDetailFactory { get; set; }
        public IMapper Mapper { get; set; }

        #endregion

        #region [ - Methods - ]

        #region [ - CreateAsync(CreateOrderDetailDTO input) - ]
        public async Task<OrderDetailDTO> CreateAsync(CreateOrderDetailDTO input)
        {
            var olderOrderDetail = await OrderDetailRepository.FindOrderDetailAsync(input.OrderHeaderId, input.ProductId);
            if (olderOrderDetail == null)
            {
                var orderDetail = await OrderDetailFactory.CreateAsync(input.OrderHeaderId, input.ProductId, input.Quantity);
                await OrderDetailRepository.InsertAsync(orderDetail);
                return Mapper.Map<Domain.Aggregates.OrderAggregate.OrderDetail, OrderDetailDTO>(orderDetail);
            }
            else
            {
                olderOrderDetail.Quantity += input.Quantity;
                await OrderDetailRepository.UpdateAsync(olderOrderDetail);
                return Mapper.Map<Domain.Aggregates.OrderAggregate.OrderDetail, OrderDetailDTO>(olderOrderDetail);
            }
        }
        #endregion

        #region [ - DeleteAsync(Guid orderHeaderId, Guid productId) - ]
        public async Task DeleteAsync(Guid orderHeaderId, Guid productId)
        {
            await OrderDetailRepository.DeleteAsync(orderHeaderId, productId);
        }
        #endregion

        #region [ - GetDetailsOfAnOrder(Guid orderHeaderId) - ]
        public async Task<List<DTOs.OrderDetailDTOs.OrderDetailDTO>> GetDetailsOfAnOrder(Guid orderHeaderId)
        {
            var orderDetails = await OrderDetailRepository.GetOrderDetailsOfAnOrder(orderHeaderId);
            return Mapper.Map<List<OrderDetailDTO>>(orderDetails);
        }
        #endregion

        #region [ - UpdateAsync(Guid orderHeaderId, Guid productId, DTOs.OrderDetailDTOs.UpdateOrderDetailDTO input) - ]
        public async Task UpdateAsync(Guid orderHeaderId, List<DTOs.OrderDetailDTOs.UpdateOrderDetailDTO> input)
        {
            var orderDetails = await OrderDetailRepository.GetOrderDetailsOfAnOrder(orderHeaderId);
            foreach (var item in orderDetails)
            {
                item.Quantity = input.Find(i => i.ProductId == item.ProductId).Quantity;
                if (item.Quantity < 1)
                {
                    await OrderDetailRepository.DeleteAsync(item);
                }
                else
                {
                    await OrderDetailRepository.UpdateAsync(item);
                }
            }

            #region [ - Adding New OrderDetails While Updating an Order (Commented) - ]
            //if (orderDetails.Count != 0)
            //{
            //    foreach (var item in orderDetails)
            //    {
            //        if (orderDetails.Select(od => od.ProductId).ToList().Contains(item.ProductId))
            //        {
            //            var orderDetail = await OrderDetailRepository.FindOrderDetailAsync(orderHeaderId, item.ProductId);
            //            item.Quantity = input.Find(i => i.ProductId == item.ProductId).Quantity;
            //            if (orderDetail.Quantity < 1)
            //            {
            //                await OrderDetailRepository.DeleteAsync(orderDetail);
            //            }
            //            else
            //            {
            //                await OrderDetailRepository.UpdateAsync(orderDetail);
            //            }
            //        }
            //        else
            //        {
            //            //var orderDetail = await CreateAsync(Mapper.Map<CreateOrderDetailDTO>(item));
            //            var orderDetail = await OrderDetailFactory.CreateAsync(item.OrderHeaderId, item.ProductId, item.Quantity);
            //            await OrderDetailRepository.InsertAsync(orderDetail);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (var item in input)
            //    {
            //        var orderDetail = await OrderDetailFactory.CreateAsync(item.OrderHeaderId, item.ProductId, item.Quantity);
            //        orderDetail.OrderHeaderId = orderHeaderId;
            //        await OrderDetailRepository.InsertAsync(orderDetail);
            //    }
            //} 
            #endregion
        } 
        #endregion

        #endregion
    } 
}
