using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.DTOs.OrderDetailDTOs
{
    public class CreateOrderDetailDTO /*: Contract.Base.DTOs.OrderDetailBaseDTO*/
    {
        Guid OrderHeaderId { get; set; }
        [JsonIgnore]
        OrderHeaderDTOs.OrderHeaderDTO OrderHeader { get; set; }

        Guid ProductId { get; set; }
        [JsonIgnore]
        Contract.Abstracts.DTOs.IProductDTO Product { get; set; }

        decimal Quantity { get; set; }
        decimal Price { get { return Product.UnitPrice * Quantity; } }

    }
}
