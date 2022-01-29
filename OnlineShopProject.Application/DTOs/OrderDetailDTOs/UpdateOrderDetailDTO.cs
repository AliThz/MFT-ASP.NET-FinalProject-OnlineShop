using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.DTOs.OrderDetailDTOs
{
    public class UpdateOrderDetailDTO /*: Contract.Base.DTOs.OrderDetailBaseDTO*/
    {
        Guid OrderHeaderId { get; set; }
        //OrderHeaderDTOs.OrderHeaderDTO OrderHeader { get; set; }

        Guid ProductId { get; set; }
        //Contract.Abstracts.DTOs.IProductDTO Product { get; set; }

        decimal Quantity { get; set; }
        //decimal Price { get { return Product.UnitPrice * Quantity; } }
    }
}
