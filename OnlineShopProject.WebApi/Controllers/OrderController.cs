using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopProject.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region [ - Ctor - ]
        public OrderController(Application.Abstracts.IOrderApplicationService orderApplicationService,
                               Application.Abstracts.IOrderDetailApplicationService orderDetailApplicationService)
        {
            OrderApplicationService = orderApplicationService;
            OrderDetailApplicationService = orderDetailApplicationService;
        }
        #endregion

        #region [ - Prop - ]
        public Application.Abstracts.IOrderApplicationService OrderApplicationService { get; set; }
        public Application.Abstracts.IOrderDetailApplicationService OrderDetailApplicationService { get; set; }
        #endregion

        #region [ - APIs - ]

        #region [ - GetDetailsOfAnOrderAsync(Guid id) - ]
        [Route("wapi/v3/1")]
        [HttpGet]
        public async Task<List<Application.DTOs.OrderDetailDTOs.OrderDetailDTO>> GetDetailsOfAnOrderAsync(Guid id)
        {
            return await OrderDetailApplicationService.GetDetailsOfAnOrder(id);
        }
        #endregion

        #region [ - GetListOrderAsync() - ]
        [Route("wapi/v3/2")]
        [HttpGet]
        public async Task<List<Application.DTOs.OrderHeaderDTOs.OrderHeaderDTO>> GetListOrderAsync()
        {
            return await OrderApplicationService.GetListAsync();
        }
        #endregion

        #region [ - CreateOrderAsync - ]
        [Route("wapi/v3/3")]
        [HttpPost]
        public async Task<Application.DTOs.OrderHeaderDTOs.OrderHeaderDTO> CreateOrderAsync(Application.DTOs.OrderHeaderDTOs.CreateOrderHeaderDTO input)
        {
            //return await OrderApplicationService.CreateAsync(input);

            var order = await OrderApplicationService.CreateAsync(input);
            var orderDetails = await OrderApplicationService.CreateOrderDetailsAsync(input.OrderDetails, order.Id);

            order.OrderDetails = orderDetails;

            return order;
        }
        #endregion

        #region [ - UpdateOrderAsync - ]
        [Route("wapi/v3/4")]
        [HttpPut]
        public async Task UpdateOrderAsync(Guid id, Application.DTOs.OrderHeaderDTOs.UpdateOrderHeaderDTO input)
        {
            await OrderApplicationService.UpdateAsync(id, input);
            await OrderDetailApplicationService.UpdateAsync(id, input.OrderDetails);
        }
        #endregion

        #region [- DeleteOrderAsync -]
        [Route("wapi/v3/5")]
        [HttpDelete]
        public async Task DeleteOrderAsync(Guid id)
        {
            await OrderApplicationService.DeleteAsync(id);
        }
        #endregion 

        #endregion
    }
}
