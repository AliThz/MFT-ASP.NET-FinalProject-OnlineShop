using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Application.Abstracts
{
    [ScopedService]
    public interface IProductApplicationService
    {
        Task<DTOs.ProductDTOs.ProductDTO> CreateAsync(DTOs.ProductDTOs.CreateProductDTO input);

        Task UpdateAsync(Guid id, DTOs.ProductDTOs.UpdateProductDTO input);

        Task DeleteAsync(Guid id);

        Task<DTOs.ProductDTOs.ProductDTO> GetAsync(Guid id);

        Task<List<DTOs.ProductDTOs.ProductDTO>> GetListAsync();

    }
}
