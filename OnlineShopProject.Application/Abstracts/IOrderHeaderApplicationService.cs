using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Application.Abstracts
{
    [ScopedService]
    public interface IOrderHeaderApplicationService
    {
        Task<DTOs.OrderHeaderDTOs.OrderHeaderDTO> CreateAsync(DTOs.OrderHeaderDTOs.CreateOrderHeaderDTO input);

        Task UpdateAsync(Guid id, DTOs.OrderHeaderDTOs.UpdateOrderHeaderDTO input);

        Task DeleteAsync(Guid id);

        Task<DTOs.OrderHeaderDTOs.OrderHeaderDTO> GetAsync(Guid id);

        Task<List<DTOs.OrderHeaderDTOs.OrderHeaderDTO>> GetListAsync();
    }
}
