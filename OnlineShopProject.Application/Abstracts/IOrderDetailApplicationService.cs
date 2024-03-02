using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Application.Abstracts
{
    [ScopedService]
    public interface IOrderDetailApplicationService
    {
        Task<DTOs.OrderDetailDTOs.OrderDetailDTO> CreateAsync(DTOs.OrderDetailDTOs.CreateOrderDetailDTO input);
        //Task<Domain.Aggregates.OrderAggregate.OrderDetail> CreateAsync(DTOs.OrderDetailDTOs.CreateOrderDetailDTO input);

        Task UpdateAsync(Guid orderHeaderId, List<DTOs.OrderDetailDTOs.UpdateOrderDetailDTO> input);

        Task DeleteAsync(Guid orderHeaderId, Guid productId);

        Task<List<DTOs.OrderDetailDTOs.OrderDetailDTO>> GetDetailsOfAnOrder(Guid orderHeaderId);
    }
}
