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
        public OrderController()
        {

        }
        #endregion

        #region [ - Prop - ]
        public Application.Abstracts.IOrderHeaderApplicationService OrderApplicationService { get; set; }
        #endregion

        #region [ - APIs - ]

        #region [ - GetOrderAsync(Guid id) - ]
        [Route("wapi/v3/1")]
        [HttpGet]
        public async Task<Application.DTOs.OrderHeaderDTOs.OrderHeaderDTO> GetOrderAsync(Guid id)
        {
            return await OrderApplicationService.GetAsync(id);
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
            return await OrderApplicationService.CreateAsync(input);
        }
        #endregion

        #region [ - UpdateOrderAsync - ]
        [Route("wapi/v3/4")]
        [HttpPut]
        public async Task UpdateOrderAsync(Guid id, Application.DTOs.OrderHeaderDTOs.UpdateOrderHeaderDTO input)
        {
            await OrderApplicationService.UpdateAsync(id, input);
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
