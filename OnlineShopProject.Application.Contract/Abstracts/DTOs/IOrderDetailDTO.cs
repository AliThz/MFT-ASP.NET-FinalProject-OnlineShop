using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Abstracts.DTOs
{
    public interface IOrderDetailDTO
    {
        Guid OrderHeaderId { get; set; }
        IOrderHeaderDTO OrderHeader { get; set; }

        Guid ProductId { get; set; }
        IProductDTO Product { get; set; }

        decimal Quantity { get; set; }
        decimal Price { get { return Product.UnitPrice * Quantity; } }
    }
}
