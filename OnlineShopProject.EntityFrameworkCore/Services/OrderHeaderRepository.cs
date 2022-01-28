using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Services
{
    public class OrderHeaderRepository :
        Frameworks.Base.BaseRepository<OnlineShopProjectDbContext, Domain.Aggregates.OrderAggregate.OrderHeader, Guid>,
        Domain.Reporities.IOrderRepository
    {
        #region [ - Ctor - ]
        public OrderHeaderRepository(OnlineShopProjectDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
