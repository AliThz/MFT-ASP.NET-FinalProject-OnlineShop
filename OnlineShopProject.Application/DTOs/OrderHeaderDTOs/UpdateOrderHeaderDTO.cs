using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.DTOs.OrderHeaderDTOs
{
    public class UpdateOrderHeaderDTO /*: Contract.Base.DTOs.OrderHeaderBaseDTO*/
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public PersonDTOs.PersonDTO Seller { get; set; }
        [JsonIgnore]
        public PersonDTOs.PersonDTO Buyer { get; set; }

        public Guid SellerId { get; set; }
        public Guid buyerId { get; set; }
        public List<OrderDetailDTOs.UpdateOrderDetailDTO> OrderDetails { get; set; }
    }
}
