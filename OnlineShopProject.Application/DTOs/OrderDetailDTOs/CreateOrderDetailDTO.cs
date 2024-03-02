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
        [JsonIgnore]
        public Guid OrderHeaderId { get; set; }
        [JsonIgnore]
        public OrderHeaderDTOs.OrderHeaderDTO OrderHeader { get; set; }

        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Contract.Abstracts.DTOs.IProductDTO Product { get; set; }

        public decimal Quantity { get; set; }
        //[JsonIgnore]
        //public decimal Price { get { return Product.UnitPrice * Quantity; } }

    }
}
