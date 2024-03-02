using OnlineShopProject.Application.Contract.Abstracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Base.DTOs
{
    public class OrderHeaderBaseDTO : Abstracts.DTOs.IOrderHeaderDTO
    {
        public PersonBaseDTO Seller { get; set; }
        public PersonBaseDTO Buyer { get; set; }
        public List<OrderDetailBaseDTO> OrderDetails { get; set; }
    }
}
