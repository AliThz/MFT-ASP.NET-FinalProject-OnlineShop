using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Application.Abstracts
{
    [ScopedService]
    public interface IOrderApplicationService
    {
        //IOrderDetailApplicationService OrderDetailApplicationService { get; set; }

        Task<DTOs.OrderHeaderDTOs.OrderHeaderDTO> CreateAsync(DTOs.OrderHeaderDTOs.CreateOrderHeaderDTO input);

        Task<List<DTOs.OrderDetailDTOs.OrderDetailDTO>> CreateOrderDetailsAsync(List<DTOs.OrderDetailDTOs.CreateOrderDetailDTO> input, Guid orderHeaderId);

        Task UpdateAsync(Guid id, DTOs.OrderHeaderDTOs.UpdateOrderHeaderDTO input);

        Task DeleteAsync(Guid id);

        Task<DTOs.OrderHeaderDTOs.OrderHeaderDTO> GetAsync(Guid id);

        Task<List<DTOs.OrderHeaderDTOs.OrderHeaderDTO>> GetListAsync();
    }
}
