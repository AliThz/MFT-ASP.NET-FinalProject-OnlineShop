using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.DTOs.OrderHeaderDTOs
{
    public class OrderHeaderDTO /*: Contract.Base.DTOs.OrderHeaderBaseDTO*/
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid SellerId { get; set; }
        [JsonIgnore]
        public Guid buyerId { get; set; }

        public PersonDTOs.PersonDTO Seller { get; set; }
        public PersonDTOs.PersonDTO Buyer { get; set; }
        public List<OrderDetailDTOs.OrderDetailDTO> OrderDetails { get; set; }
    }
}
