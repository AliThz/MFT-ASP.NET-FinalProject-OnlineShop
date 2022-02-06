using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.DTOs.OrderDetailDTOs
{
    public class OrderDetailDTO /*: Contract.Base.DTOs.OrderDetailBaseDTO*/
    {
        public Guid OrderHeaderId { get; set; }
        [JsonIgnore]
        public OrderHeaderDTOs.OrderHeaderDTO OrderHeader { get; set; }

        public Guid ProductId { get; set; }
        [JsonIgnore]
        public ProductDTOs.ProductDTO Product { get; set; }
        //public Contract.Abstracts.DTOs.IProductDTO Product { get; set; }

        public decimal Quantity { get; set; }

        //public decimal Price { get { return Product.UnitPrice * Quantity; } }

    }
}
