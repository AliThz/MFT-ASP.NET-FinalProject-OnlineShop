using AutoMapper;
using OnlineShopProject.Application.Abstracts;
using OnlineShopProject.Application.DTOs.OrderDetailDTOs;
using OnlineShopProject.Application.DTOs.OrderHeaderDTOs;
using OnlineShopProject.Application.DTOs.PersonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Services
{
    public class OrderApplicationService : Abstracts.IOrderApplicationService
    {
        #region [ - Ctor - ]
        public OrderApplicationService(Domain.Reporities.IOrderRepository orderRepository,
                                       Domain.Reporities.IOrderDetailRepository orderDetailRepository,
                                       Domain.Factories.OrderFactory.OrderFactoryService orderFactory,
                                       Domain.Factories.OrderFactory.OrderDetailFactoryService orderDetailFactory,
                                       IOrderDetailApplicationService orderDetailApplicationService,
                                       Domain.Reporities.IPersonRepository personRepository,
                                       IMapper mapper)
        {
            OrderRepository = orderRepository;
            OrderDetailRepository = orderDetailRepository;
            OrderFactory = orderFactory;
            PersonRepository= personRepository;
            OrderDetailFactory = orderDetailFactory;
            OrderDetailApplicationService = orderDetailApplicationService;
            Mapper = mapper;
        }
        #endregion

        #region [ - Props - ]
        public Domain.Reporities.IOrderRepository OrderRepository { get; set; }
        public Domain.Factories.OrderFactory.OrderFactoryService OrderFactory { get; set; }
        public Domain.Factories.OrderFactory.OrderDetailFactoryService OrderDetailFactory { get; set; }
        public Domain.Reporities.IOrderDetailRepository OrderDetailRepository { get; set; }
        public IOrderDetailApplicationService OrderDetailApplicationService { get; set; }
        public Domain.Reporities.IPersonRepository PersonRepository { get; set; }
        public IMapper Mapper { get; set; }
        //IOrderDetailApplicationService IOrderApplicationService.OrderDetailApplicationService { get; set; }
        #endregion

        #region [ - Methods - ]

        #region [ - CreateAsync(CreateOrderHeaderDTO input) - ]
        public async Task<OrderHeaderDTO> CreateAsync(CreateOrderHeaderDTO input)
        {
            //var orderDetails = new List<DTOs.OrderDetailDTOs.OrderDetailDTO>();
            //foreach (var item in input.OrderDetails)
            //{
            //    var orderDetail = new DTOs.OrderDetailDTOs.OrderDetailDTO();
            //    orderDetail.ProductId = item.ProductId;
            //}

            var order = await OrderFactory.CreateAsync(await PersonRepository.FindByIdAsync(input.SellerId),
                                                       await PersonRepository.FindByIdAsync(input.buyerId));

            //var order = await OrderFactory.CreateAsync(await PersonRepository.FindByIdAsync(input.SellerId),
            //                                           await PersonRepository.FindByIdAsync(input.buyerId),
            //                                           Mapper.Map<List<OrderDetailDTO>, List<Domain.Aggregates.OrderAggregate.OrderDetail>>(input.OrderDetails));

            //var order = await OrderFactory.CreateAsync(Mapper.Map<PersonDTO, Domain.Aggregates.PersonAggregate.Person>(input.Seller),
            //                                           Mapper.Map<PersonDTO, Domain.Aggregates.PersonAggregate.Person>(input.Buyer),
            //                                           Mapper.Map<List<OrderDetailDTO>, List<Domain.Aggregates.OrderAggregate.OrderDetail>>(input.OrderDetails));
            await OrderRepository.InsertAsync(order);
            return Mapper.Map<Domain.Aggregates.OrderAggregate.OrderHeader, OrderHeaderDTO>(order);
        }
        #endregion

        #region [ - CreateOrderDetailsAsync(CreateOrderDetailDTO input) - ]
        public async Task<List<OrderDetailDTO>> CreateOrderDetailsAsync(List<DTOs.OrderDetailDTOs.CreateOrderDetailDTO> input, Guid orderheaderId)
        {
            var orderDetails = new List<OrderDetailDTO>();
            foreach (var item in input)
            {
                item.OrderHeaderId = orderheaderId;
                var orderDetail = await OrderDetailApplicationService.CreateAsync(item);
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        #endregion

        #region [ - DeleteAsync(Guid id) - ]
        public async Task DeleteAsync(Guid id)
        {
            foreach (var item in await OrderDetailApplicationService.GetDetailsOfAnOrder(id))
            {
                await OrderDetailApplicationService.DeleteAsync(item.OrderHeaderId, item.ProductId);
            }
            await OrderRepository.DeleteAsync(id);
        }
        // OrderRepository.DeleteAsync has another overload
        #endregion

        #region [ - GetAsync(Guid id) - ]
        public async Task<OrderHeaderDTO> GetAsync(Guid id)
        {
            var order = await OrderRepository.FindByIdAsync(id);
            return Mapper.Map<OrderHeaderDTO>(order);
        }
        #endregion

        #region [ - GetListAsync() - ]
        public async Task<List<OrderHeaderDTO>> GetListAsync()
        {
            var orders = await OrderRepository.SelectAsync();
            var mappedOrders = Mapper.Map<List<Domain.Aggregates.OrderAggregate.OrderHeader>, List<OrderHeaderDTO>>(orders);
            return mappedOrders;
        }
        #endregion

        #region [ - UpdateAsync(Guid id, UpdateOrderHeaderDTO input) - ]
        public async Task UpdateAsync(Guid id, UpdateOrderHeaderDTO input)
        {
            var order = await OrderRepository.FindByIdAsync(id);
            if (order != null)
            {
                order.Seller = await PersonRepository.FindByIdAsync(input.SellerId);
                order.Buyer = await PersonRepository.FindByIdAsync(input.buyerId);

                await OrderRepository.UpdateAsync(order);
            }
        }
        #endregion

        #endregion
    }
}
