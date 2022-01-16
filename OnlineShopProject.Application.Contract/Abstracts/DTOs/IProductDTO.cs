using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Abstracts.DTOs
{
    public interface IProductDTO
    {
        string Title { get; set; }
        decimal UnitPrice { get; set; }
        decimal Quantity { get; set; }
    }
}
