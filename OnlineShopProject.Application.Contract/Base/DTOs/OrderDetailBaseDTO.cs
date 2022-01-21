using OnlineShopProject.Application.Contract.Abstracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Base.DTOs
{
    public class OrderDetailBaseDTO : Abstracts.DTOs.IOrderDetailDTO
    {
        public Guid OrderHeaderId { get; set; }
        public IOrderHeaderDTO OrderHeader { get; set; }
        public Guid ProductId { get; set; }
        public IProductDTO Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
