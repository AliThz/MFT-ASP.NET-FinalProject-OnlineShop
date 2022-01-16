using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region [ - Ctor - ]
        public ProductController(Application.Abstracts.IProductApplicationService productApplicationService)
        {
            ProductApplicationService = productApplicationService;
        }
        #endregion

        #region [ - Prop - ]
        public Application.Abstracts.IProductApplicationService ProductApplicationService { get; set; }
        #endregion

        #region [ - Actions - ]

        #region [ - GetProductAsync(Guid id) - ]
        [Route("wapi/v2/1")]
        [HttpGet]
        public async Task<Application.DTOs.ProductDTOs.ProductDTO> GetProductAsync(Guid id)
        {
            return await ProductApplicationService.GetAsync(id);
        }
        #endregion

        #region [ - GetListProductAsync() - ]
        [Route("wapi/v2/2")]
        [HttpGet]
        public async Task<List<Application.DTOs.ProductDTOs.ProductDTO>> GetListProductAsync()
        {
            return await ProductApplicationService.GetListAsync();
        }
        #endregion

        #region [ - CreateProductAsync - ]
        [Route("wapi/v2/3")]
        [HttpPost]
        public async Task<Application.DTOs.ProductDTOs.ProductDTO> CreateProductAsync(Application.DTOs.ProductDTOs.CreateProductDTO input)
        {
            return await ProductApplicationService.CreateAsync(input);
        }
        #endregion

        #region [ - UpdateProductAsync - ]
        [Route("wapi/v2/4")]
        [HttpPut]
        public async Task UpdateProductAsync(Guid id, Application.DTOs.ProductDTOs.UpdateProductDTO input)
        {
            await ProductApplicationService.UpdateAsync(id, input);
        }
        #endregion

        #region [- DeleteProductAsync -]
        [Route("wapi/v2/5")]
        [HttpDelete]
        public async Task DeleteProductAsync(Guid id)
        {
            await ProductApplicationService.DeleteAsync(id);
        }
        #endregion 

        #endregion
    }
}
