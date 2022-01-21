using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.DTOs.OrderHeaderDTOs
{
    public class CreateOrderHeaderDTO /*: Contract.Base.DTOs.OrderHeaderBaseDTO*/
    {
        public PersonDTOs.PersonDTO Seller { get; set; }
        public PersonDTOs.PersonDTO Buyer { get; set; }
        public List<OrderDetailDTOs.OrderDetailDTO> OrderDetails { get; set; }
    }
}
