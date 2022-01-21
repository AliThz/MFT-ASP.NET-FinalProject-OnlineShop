using AutoMapper;
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
    public class OrderApplicationService : Abstracts.IOrderHeaderApplicationService
    {
        #region [ - Ctor - ]
        public OrderApplicationService(Domain.Reporities.IOrderRepository orderRepository,
                                       Domain.Factories.OrderFactory.OrderFactoryService orderFactory,
                                       Domain.Factories.OrderFactory.OrderDetailFactoryService orderDetailFactory,
                                       Domain.Reporities.IPersonRepository personRepository,
                                       IMapper mapper)
        {
            OrderRepository = orderRepository;
            OrderFactory = orderFactory;
            OrderDetailFactory = orderDetailFactory;
            PersonRepository= personRepository;
            Mapper = mapper;
        }
        #endregion

        #region [ - Props - ]
        public Domain.Reporities.IOrderRepository OrderRepository { get; set; }
        public Domain.Factories.OrderFactory.OrderFactoryService OrderFactory { get; set; }
        public Domain.Factories.OrderFactory.OrderDetailFactoryService OrderDetailFactory { get; set; }
        public Domain.Reporities.IPersonRepository PersonRepository { get; set; }
        public IMapper Mapper { get; set; }
        #endregion

        #region [ - Methods - ]

        #region [ - CreateAsync(CreateOrderHeaderDTO input) - ]
        public async Task<OrderHeaderDTO> CreateAsync(CreateOrderHeaderDTO input)
        {
            var order = await OrderFactory.CreateAsync(Mapper.Map<PersonDTO, Domain.Aggregates.PersonAggregate.Person>(input.Seller),
                                                       Mapper.Map<PersonDTO, Domain.Aggregates.PersonAggregate.Person>(input.Buyer),
                                                       Mapper.Map<List<OrderDetailDTO>, List<Domain.Aggregates.OrderAggregate.OrderDetail>>(input.OrderDetails));
            await OrderRepository.InsertAsync(order);
            return Mapper.Map<Domain.Aggregates.OrderAggregate.OrderHeader, OrderHeaderDTO>(order);
        }
        #endregion

        #region [ - DeleteAsync(Guid id) - ]
        public async Task DeleteAsync(Guid id)
        {
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
            var orders = await OrderRepository.Select();
            return Mapper.Map<List<OrderHeaderDTO>>(orders);
        }
        #endregion

        #region [ - UpdateAsync(Guid id, UpdateOrderHeaderDTO input) - ]
        public async Task UpdateAsync(Guid id, UpdateOrderHeaderDTO input)
        {
            var order = await OrderRepository.FindByIdAsync(id);
            if (order != null)
            {
                order.Seller.FirstName = input.Seller.FirstName;
                order.Seller.LastName = input.Seller.LastName;
                order.Buyer.FirstName = input.Buyer.FirstName;
                order.Buyer.LastName = input.Buyer.LastName;
                order.OrderDetails.Clear();
                input.OrderDetails.ForEach(od => order.OrderDetails.Add(Mapper.Map<Domain.Aggregates.OrderAggregate.OrderDetail>(od)));

                await OrderRepository.UpdateAsync(order);
            }
        }
        #endregion

        #endregion
    }
}
