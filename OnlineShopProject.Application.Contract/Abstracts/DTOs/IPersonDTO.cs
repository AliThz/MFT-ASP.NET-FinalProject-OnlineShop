using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Abstracts.DTOs
{
    public interface IPersonDTO
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
