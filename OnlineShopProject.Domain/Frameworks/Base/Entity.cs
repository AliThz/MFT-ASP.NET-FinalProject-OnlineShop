using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Frameworks.Base
{
    public class Entity : Abstracts.IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
