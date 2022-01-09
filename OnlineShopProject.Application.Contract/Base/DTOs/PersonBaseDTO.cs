using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Contract.Base.DTOs
{
    public class PersonBaseDTO : Abstracts.DTOs.IPersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
