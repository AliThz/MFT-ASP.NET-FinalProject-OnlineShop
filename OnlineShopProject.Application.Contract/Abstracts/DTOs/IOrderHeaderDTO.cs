using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Abstracts.DTOs
{
    public interface IOrderHeaderDTO
    {
        Base.DTOs.PersonBaseDTO Seller { get; set; }
        Base.DTOs.PersonBaseDTO Buyer { get; set; }

        List<Base.DTOs.OrderDetailBaseDTO> OrderDetails { get; set; }
    }
}
